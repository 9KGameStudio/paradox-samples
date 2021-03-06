﻿using SiliconStudio.Core.Mathematics;
using SiliconStudio.Paradox.Engine;
using SiliconStudio.Paradox.Rendering;
using SiliconStudio.Paradox.Rendering.Composers;
using SiliconStudio.Paradox.Graphics;

namespace CustomEffect
{
    /// <summary>
    /// The script in charge of rendering the custom effect
    /// </summary>
    public class EffectScript : Script
    {
        private Effect customEffect;
        private PrimitiveQuad quad;
        private Texture paradoxTexture;
        private SamplerState samplingState;

        public override void Start()
        {
            base.Start();
            
            paradoxTexture = Asset.Load<Texture>("LogoParadox");
            customEffect = EffectSystem.LoadEffect("CustomEffect").WaitForResult();
            quad = new PrimitiveQuad(GraphicsDevice, customEffect);

            // set fixed parameters once
            quad.Parameters.Set(CustomEffectKeys.Center, new Vector2(0.5f, 0.5f));
            quad.Parameters.Set(CustomEffectKeys.Frequency, 40);
            quad.Parameters.Set(CustomEffectKeys.Spread, 0.5f);
            quad.Parameters.Set(CustomEffectKeys.Amplitude, 0.015f);
            quad.Parameters.Set(CustomEffectKeys.InvAspectRatio, GraphicsDevice.BackBuffer.Height / (float)GraphicsDevice.BackBuffer.Width);

            // NOTE: Linear-Wrap sampling is not available for non-square non-power-of-two textures on opengl es 2.0
            samplingState = SamplerState.New(GraphicsDevice, new SamplerStateDescription(TextureFilter.Linear, TextureAddressMode.Clamp));
            
            // Add Effect rendering to the end of the pipeline
            var scene = SceneSystem.SceneInstance.Scene;
            var compositor = ((SceneGraphicsCompositorLayers)scene.Settings.GraphicsCompositor);
            compositor.Master.Renderers.Add(new SceneDelegateRenderer(RenderQuad));
        }

        private void RenderQuad(RenderContext renderContext, RenderFrame frame)
        {
            GraphicsDevice.SetBlendState(GraphicsDevice.BlendStates.NonPremultiplied);
            quad.Parameters.Set(CustomEffectKeys.Phase, -3 * (float)Game.UpdateTime.Total.TotalSeconds);
            quad.Draw(paradoxTexture, samplingState, Color.White);
        }
    }
}
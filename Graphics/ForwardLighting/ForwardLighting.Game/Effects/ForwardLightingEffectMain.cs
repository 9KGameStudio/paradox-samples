// <auto-generated>
// Do not edit this file yourself!
//
// This code was generated by Paradox Shader Mixin Code Generator.
// To generate it yourself, please install SiliconStudio.Paradox.VisualStudio.Package .vsix
// and re-save the associated .pdxfx.
// </auto-generated>

using SiliconStudio.Core;
using SiliconStudio.Paradox.Effects;
using SiliconStudio.Paradox.Shaders;
using SiliconStudio.Core.Mathematics;
using SiliconStudio.Paradox.Graphics;


#line 1 "C:\Projects\Paradox\samples2\Graphics\ForwardLighting\ForwardLighting.Game\Effects\ForwardLightingEffectMain.pdxfx"
namespace ForwardLighting.Effects
{

    #line 3
    public partial class ForwardLightingEffectMain  : IShaderMixinBuilder
    {
        public void Generate(ShaderMixinSourceTree mixin, ShaderMixinContext context)
        {

            #line 5
            context.Mixin(mixin, "ParadoxDefaultForwardShader");
        }

        [ModuleInitializer]
        internal static void __Initialize__()

        {
            ShaderMixinManager.Register("ForwardLightingEffectMain", new ForwardLightingEffectMain());
        }
    }
}
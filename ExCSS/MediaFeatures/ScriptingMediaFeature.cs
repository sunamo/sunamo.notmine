
namespace ExCSS
{
    public sealed class ScriptingMediaFeature : MediaFeature
    {
        private static readonly IValueConverter TheConverter = Map.ScriptingStates.ToConverter();

        public ScriptingMediaFeature()
            : base(FeatureNames.Scripting)
        {
        }

        public override IValueConverter Converter => TheConverter;
    }
}

namespace ExCSS
{
    public sealed class UpdateFrequencyMediaFeature : MediaFeature
    {
        private static readonly IValueConverter TheConverter = Map.UpdateFrequencies.ToConverter();

        public UpdateFrequencyMediaFeature()
            : base(FeatureNames.UpdateFrequency)
        {
        }

        public override IValueConverter Converter => TheConverter;

    }
}
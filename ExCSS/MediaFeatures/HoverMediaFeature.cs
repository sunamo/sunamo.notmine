
namespace ExCSS
{
    public sealed class HoverMediaFeature : MediaFeature
    {
        private static readonly IValueConverter TheConverter = Map.HoverAbilities.ToConverter();

        public HoverMediaFeature()
            : base(FeatureNames.Hover)
        {
        }

        public override IValueConverter Converter => TheConverter;
    }
}
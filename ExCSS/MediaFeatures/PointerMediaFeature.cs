
namespace ExCSS
{
    public sealed class PointerMediaFeature : MediaFeature
    {
        private static readonly IValueConverter TheConverter = Map.PointerAccuracies.ToConverter();

        public PointerMediaFeature()
            : base(FeatureNames.Pointer)
        {
        }

        public override IValueConverter Converter => TheConverter;
    }
}
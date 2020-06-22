
namespace ExCSS
{
    public sealed class GridMediaFeature : MediaFeature
    {
        public GridMediaFeature()
            : base(FeatureNames.Grid)
        {
        }

        public override IValueConverter Converter => Converters.BinaryConverter;

    }
}
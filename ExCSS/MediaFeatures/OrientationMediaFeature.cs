
namespace ExCSS
{
    public sealed class OrientationMediaFeature : MediaFeature
    {
        private static readonly IValueConverter TheConverter = Converters.Toggle(Keywords.Portrait, Keywords.Landscape);

        public OrientationMediaFeature()
            : base(FeatureNames.Orientation)
        {
        }

        public override IValueConverter Converter => TheConverter;

    }
}
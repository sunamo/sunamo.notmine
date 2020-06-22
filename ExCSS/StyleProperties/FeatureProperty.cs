
namespace ExCSS
{
    public sealed class FeatureProperty : Property
    {
        public FeatureProperty(MediaFeature feature)
            : base(feature.Name)
        {
            Feature = feature;
        }


        public override IValueConverter Converter => Feature.Converter;

        public MediaFeature Feature { get; }
    }
}
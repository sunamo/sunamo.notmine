
namespace ExCSS
{
    public sealed class ScanMediaFeature : MediaFeature
    {

        private static readonly IValueConverter TheConverter = Converters.Toggle(Keywords.Interlace,
            Keywords.Progressive);

        public ScanMediaFeature()
            : base(FeatureNames.Scan)
        {
        }

        public override IValueConverter Converter => TheConverter;
    }
}
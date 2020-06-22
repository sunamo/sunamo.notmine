
namespace ExCSS
{
    public sealed class HeightMediaFeature : MediaFeature
    {
        public HeightMediaFeature(string name)
            : base(name)
        {
        }

        public override IValueConverter Converter => Converters.LengthConverter;

    }
}
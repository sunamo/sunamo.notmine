
namespace ExCSS
{
    public sealed class WidthMediaFeature : MediaFeature
    {
        public WidthMediaFeature(string name)
            : base(name)
        {
        }

        public override IValueConverter Converter => Converters.LengthConverter;

    }
}
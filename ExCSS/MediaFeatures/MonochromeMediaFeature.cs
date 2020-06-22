
namespace ExCSS
{
    using static Converters;

    public sealed class MonochromeMediaFeature : MediaFeature
    {
        public MonochromeMediaFeature(string name)
            : base(name)
        {
        }

        public override IValueConverter Converter => IsMinimum || IsMaximum ? NaturalIntegerConverter : NaturalIntegerConverter.Option(1);

    }
}
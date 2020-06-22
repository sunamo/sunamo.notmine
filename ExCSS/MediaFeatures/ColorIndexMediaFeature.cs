
namespace ExCSS
{
    using static Converters;

    public sealed class ColorIndexMediaFeature : MediaFeature
    {
        public ColorIndexMediaFeature(string name) : base(name)
        {
        }

        public override IValueConverter Converter => 
            IsMinimum || IsMaximum 
            ? NaturalIntegerConverter 
            : NaturalIntegerConverter.Option(1);

    }
}
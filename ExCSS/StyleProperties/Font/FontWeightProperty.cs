
namespace ExCSS
{
    using static Converters;

    public sealed class FontWeightProperty : Property
    {
        private static readonly IValueConverter StyleConverter = FontWeightConverter.Or(
            WeightIntegerConverter).OrDefault(FontWeight.Normal);

        public FontWeightProperty()
            : base(PropertyNames.FontWeight, PropertyFlags.Inherited | PropertyFlags.Animatable)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}
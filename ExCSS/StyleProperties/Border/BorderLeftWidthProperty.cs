
namespace ExCSS
{
    public sealed class BorderLeftWidthProperty : Property
    {
        private static readonly IValueConverter StyleConverter = Converters.LineWidthConverter.OrDefault(Length.Medium);

        public BorderLeftWidthProperty()
            : base(PropertyNames.BorderLeftWidth, PropertyFlags.Unitless | PropertyFlags.Animatable)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}
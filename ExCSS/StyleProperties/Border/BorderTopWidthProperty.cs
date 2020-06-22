
namespace ExCSS
{
    public sealed class BorderTopWidthProperty : Property
    {
        private static readonly IValueConverter StyleConverter = Converters.LineWidthConverter.OrDefault(Length.Medium);

        public BorderTopWidthProperty()
            : base(PropertyNames.BorderTopWidth, PropertyFlags.Unitless | PropertyFlags.Animatable)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}
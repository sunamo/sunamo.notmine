
namespace ExCSS
{
    public sealed class BorderBottomWidthProperty : Property
    {
        private static readonly IValueConverter StyleConverter = Converters.LineWidthConverter.OrDefault(Length.Medium);

        public BorderBottomWidthProperty()
            : base(PropertyNames.BorderBottomWidth, PropertyFlags.Unitless | PropertyFlags.Animatable)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}
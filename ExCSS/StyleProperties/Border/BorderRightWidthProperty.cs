
namespace ExCSS
{
    public sealed class BorderRightWidthProperty : Property
    {
        private static readonly IValueConverter StyleConverter = Converters.LineWidthConverter.OrDefault(Length.Medium);

        public BorderRightWidthProperty()
            : base(PropertyNames.BorderRightWidth, PropertyFlags.Unitless | PropertyFlags.Animatable)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}
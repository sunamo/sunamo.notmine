
namespace ExCSS
{
    public sealed class BorderBottomRightRadiusProperty : Property
    {
        private static readonly IValueConverter StyleConverter = Converters.BorderRadiusConverter.OrDefault(Length.Zero);

        public BorderBottomRightRadiusProperty()
            : base(PropertyNames.BorderBottomRightRadius, PropertyFlags.Animatable)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}
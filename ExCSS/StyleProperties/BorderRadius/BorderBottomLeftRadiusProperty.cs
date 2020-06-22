
namespace ExCSS
{
    public sealed class BorderBottomLeftRadiusProperty : Property
    {
        private static readonly IValueConverter StyleConverter = Converters.BorderRadiusConverter.OrDefault(Length.Zero);

        public BorderBottomLeftRadiusProperty()
            : base(PropertyNames.BorderBottomLeftRadius, PropertyFlags.Animatable)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}
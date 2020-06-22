
namespace ExCSS
{
    public sealed class BorderTopRightRadiusProperty : Property
    {
        private static readonly IValueConverter StyleConverter = Converters.BorderRadiusConverter.OrDefault(Length.Zero);

        public BorderTopRightRadiusProperty()
            : base(PropertyNames.BorderTopRightRadius, PropertyFlags.Animatable)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}

namespace ExCSS
{
    public sealed class BorderTopLeftRadiusProperty : Property
    {
        private static readonly IValueConverter StyleConverter = Converters.BorderRadiusConverter.OrDefault(Length.Zero);

        public BorderTopLeftRadiusProperty()
            : base(PropertyNames.BorderTopLeftRadius, PropertyFlags.Animatable)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}
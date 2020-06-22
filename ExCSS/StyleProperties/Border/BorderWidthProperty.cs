
namespace ExCSS
{
    public sealed class BorderWidthProperty : ShorthandProperty
    {
        private static readonly IValueConverter StyleConverter = Converters.LineWidthConverter.Periodic(
            PropertyNames.BorderTopWidth, PropertyNames.BorderRightWidth, PropertyNames.BorderBottomWidth,
            PropertyNames.BorderLeftWidth).OrDefault();

        public BorderWidthProperty()
            : base(PropertyNames.BorderWidth, PropertyFlags.Animatable)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}
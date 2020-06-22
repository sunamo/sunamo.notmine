
namespace ExCSS
{
    public sealed class BorderStyleProperty : ShorthandProperty
    {
        private static readonly IValueConverter StyleConverter = Converters.LineStyleConverter.Periodic(
            PropertyNames.BorderTopStyle, PropertyNames.BorderRightStyle, PropertyNames.BorderBottomStyle,
            PropertyNames.BorderLeftStyle).OrDefault();

        public BorderStyleProperty()
            : base(PropertyNames.BorderStyle)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}
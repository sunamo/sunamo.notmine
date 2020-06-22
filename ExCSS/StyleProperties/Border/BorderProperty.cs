
namespace ExCSS
{
    using static Converters;

    public sealed class BorderProperty : ShorthandProperty
    {
        private static readonly IValueConverter StyleConverter = WithAny(
            LineWidthConverter.Option()
                .For(PropertyNames.BorderTopWidth, PropertyNames.BorderRightWidth, PropertyNames.BorderBottomWidth,
                    PropertyNames.BorderLeftWidth),
            LineStyleConverter.Option()
                .For(PropertyNames.BorderTopStyle, PropertyNames.BorderRightStyle, PropertyNames.BorderBottomStyle,
                    PropertyNames.BorderLeftStyle),
            CurrentColorConverter.Option()
                .For(PropertyNames.BorderTopColor, PropertyNames.BorderRightColor, PropertyNames.BorderBottomColor,
                    PropertyNames.BorderLeftColor)
        ).OrDefault();

        public BorderProperty()
            : base(PropertyNames.Border, PropertyFlags.Animatable)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}
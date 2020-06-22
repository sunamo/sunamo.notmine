
namespace ExCSS
{
    using static Converters;

    public sealed class BorderBottomProperty : ShorthandProperty
    {
        private static readonly IValueConverter StyleConverter = WithAny(
            LineWidthConverter.Option().For(PropertyNames.BorderBottomWidth),
            LineStyleConverter.Option().For(PropertyNames.BorderBottomStyle),
            CurrentColorConverter.Option().For(PropertyNames.BorderBottomColor)
        ).OrDefault();

        public BorderBottomProperty()
            : base(PropertyNames.BorderBottom, PropertyFlags.Animatable)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}
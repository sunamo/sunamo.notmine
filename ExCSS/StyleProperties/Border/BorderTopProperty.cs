
namespace ExCSS
{
    using static Converters;

    public sealed class BorderTopProperty : ShorthandProperty
    {
        private static readonly IValueConverter StyleConverter = WithAny(
            LineWidthConverter.Option().For(PropertyNames.BorderTopWidth),
            LineStyleConverter.Option().For(PropertyNames.BorderTopStyle),
            CurrentColorConverter.Option().For(PropertyNames.BorderTopColor)
        ).OrDefault();

        public BorderTopProperty()
            : base(PropertyNames.BorderTop, PropertyFlags.Animatable)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}
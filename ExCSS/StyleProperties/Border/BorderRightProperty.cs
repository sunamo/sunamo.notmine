
namespace ExCSS
{
    using static Converters;

    public sealed class BorderRightProperty : ShorthandProperty
    {
        private static readonly IValueConverter StyleConverter = WithAny(
            LineWidthConverter.Option().For(PropertyNames.BorderRightWidth),
            LineStyleConverter.Option().For(PropertyNames.BorderRightStyle),
            CurrentColorConverter.Option().For(PropertyNames.BorderRightColor)
        ).OrDefault();

        public BorderRightProperty()
            : base(PropertyNames.BorderRight, PropertyFlags.Animatable)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}
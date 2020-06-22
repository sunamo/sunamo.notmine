
namespace ExCSS
{
    using static Converters;

    public sealed class BorderLeftProperty : ShorthandProperty
    {
        private static readonly IValueConverter StyleConverter = WithAny(
            LineWidthConverter.Option().For(PropertyNames.BorderLeftWidth),
            LineStyleConverter.Option().For(PropertyNames.BorderLeftStyle),
            CurrentColorConverter.Option().For(PropertyNames.BorderLeftColor)
        ).OrDefault();

        public BorderLeftProperty()
            : base(PropertyNames.BorderLeft, PropertyFlags.Animatable)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}
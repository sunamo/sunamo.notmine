
namespace ExCSS
{
    using static Converters;

    public sealed class OutlineProperty : ShorthandProperty
    {
        private static readonly IValueConverter StyleConverter = WithAny(
            LineWidthConverter.Option().For(PropertyNames.OutlineWidth),
            LineStyleConverter.Option().For(PropertyNames.OutlineStyle),
            InvertedColorConverter.Option().For(PropertyNames.OutlineColor)).OrDefault();

        public OutlineProperty()
            : base(PropertyNames.Outline, PropertyFlags.Animatable)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}
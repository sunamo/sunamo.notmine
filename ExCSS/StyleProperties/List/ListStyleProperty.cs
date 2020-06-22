
namespace ExCSS
{
    using static Converters;

    public sealed class ListStyleProperty : ShorthandProperty
    {
        private static readonly IValueConverter StyleConverter = WithAny(
            ListStyleConverter.Option().For(PropertyNames.ListStyleType),
            ListPositionConverter.Option().For(PropertyNames.ListStylePosition),
            OptionalImageSourceConverter.Option().For(PropertyNames.ListStyleImage)).OrDefault();

        public ListStyleProperty()
            : base(PropertyNames.ListStyle, PropertyFlags.Inherited)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}
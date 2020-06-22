
namespace ExCSS
{
    using static Converters;

    public sealed class ColumnsProperty : ShorthandProperty
    {
        private static readonly IValueConverter StyleConverter = WithAny(
            AutoLengthConverter.Option().For(PropertyNames.ColumnWidth),
            OptionalIntegerConverter.Option().For(PropertyNames.ColumnCount)).OrDefault();

        public ColumnsProperty()
            : base(PropertyNames.Columns, PropertyFlags.Animatable)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}
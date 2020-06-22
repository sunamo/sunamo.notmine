
namespace ExCSS
{
    public sealed class ColumnFillProperty : Property
    {
        private static readonly IValueConverter StyleConverter = Converters.ColumnFillConverter.OrDefault(true);

        public ColumnFillProperty()
            : base(PropertyNames.ColumnFill)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}
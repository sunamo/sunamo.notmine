
namespace ExCSS
{
    public sealed class ColumnSpanProperty : Property
    {
        private static readonly IValueConverter StyleConverter = Converters.ColumnSpanConverter.OrDefault(false);

        public ColumnSpanProperty()
            : base(PropertyNames.ColumnSpan)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}
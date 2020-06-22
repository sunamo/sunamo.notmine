
namespace ExCSS
{
    public sealed class ColumnWidthProperty : Property
    {
        private static readonly IValueConverter StyleConverter = Converters.AutoLengthConverter.OrDefault(Keywords.Auto);

        public ColumnWidthProperty()
            : base(PropertyNames.ColumnWidth, PropertyFlags.Animatable)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}

namespace ExCSS
{
    public sealed class TableLayoutProperty : Property
    {
        private static readonly IValueConverter StyleConverter = Converters.TableLayoutConverter.OrDefault(false);

        public TableLayoutProperty()
            : base(PropertyNames.TableLayout)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}
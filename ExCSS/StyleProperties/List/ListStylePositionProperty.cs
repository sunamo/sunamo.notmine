
namespace ExCSS
{
    public sealed class ListStylePositionProperty : Property
    {
        private static readonly IValueConverter StyleConverter =
            Converters.ListPositionConverter.OrDefault(ListPosition.Outside);

        public ListStylePositionProperty()
            : base(PropertyNames.ListStylePosition, PropertyFlags.Inherited)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}
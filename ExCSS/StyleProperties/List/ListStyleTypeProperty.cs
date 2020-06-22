
namespace ExCSS
{
    public sealed class ListStyleTypeProperty : Property
    {
        private static readonly IValueConverter StyleConverter = Converters.ListStyleConverter.OrDefault(ListStyle.Disc);

        public ListStyleTypeProperty()
            : base(PropertyNames.ListStyleType, PropertyFlags.Inherited)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}
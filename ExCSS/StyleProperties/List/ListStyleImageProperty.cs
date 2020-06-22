
namespace ExCSS
{
    public sealed class ListStyleImageProperty : Property
    {
        private static readonly IValueConverter StyleConverter = Converters.OptionalImageSourceConverter.OrDefault();

        public ListStyleImageProperty()
            : base(PropertyNames.ListStyleImage, PropertyFlags.Inherited)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}
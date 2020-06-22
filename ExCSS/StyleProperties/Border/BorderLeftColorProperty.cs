
namespace ExCSS
{
    public sealed class BorderLeftColorProperty : Property
    {
        private static readonly IValueConverter StyleConverter =
            Converters.CurrentColorConverter.OrDefault(Color.Transparent);

        public BorderLeftColorProperty()
            : base(PropertyNames.BorderLeftColor)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}
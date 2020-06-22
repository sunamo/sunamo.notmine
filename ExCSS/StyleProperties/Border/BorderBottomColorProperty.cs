
namespace ExCSS
{
    public sealed class BorderBottomColorProperty : Property
    {
        private static readonly IValueConverter StyleConverter =
            Converters.CurrentColorConverter.OrDefault(Color.Transparent);

        public BorderBottomColorProperty()
            : base(PropertyNames.BorderBottomColor)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}

namespace ExCSS
{
    public sealed class BorderRightColorProperty : Property
    {
        private static readonly IValueConverter StyleConverter =
            Converters.CurrentColorConverter.OrDefault(Color.Transparent);

        public BorderRightColorProperty()
            : base(PropertyNames.BorderRightColor)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}
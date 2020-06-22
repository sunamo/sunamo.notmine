
namespace ExCSS
{
    public sealed class TextDecorationStyleProperty : Property
    {
        private static readonly IValueConverter StyleConverter =
            Converters.TextDecorationStyleConverter.OrDefault(TextDecorationStyle.Solid);

        public TextDecorationStyleProperty()
            : base(PropertyNames.TextDecorationStyle)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}
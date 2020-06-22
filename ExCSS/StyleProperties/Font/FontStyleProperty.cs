
namespace ExCSS
{
    public sealed class FontStyleProperty : Property
    {
        private static readonly IValueConverter StyleConverter =
            Converters.FontStyleConverter.OrDefault(FontStyle.Normal);

        public FontStyleProperty()
            : base(PropertyNames.FontStyle, PropertyFlags.Inherited)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}
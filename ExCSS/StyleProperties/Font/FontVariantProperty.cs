
namespace ExCSS
{
    public sealed class FontVariantProperty : Property
    {
        private static readonly IValueConverter StyleConverter =
            Converters.FontVariantConverter.OrDefault(FontVariant.Normal);

        public FontVariantProperty()
            : base(PropertyNames.FontVariant, PropertyFlags.Inherited)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}
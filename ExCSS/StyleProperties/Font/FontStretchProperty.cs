
namespace ExCSS
{
    public sealed class FontStretchProperty : Property
    {
        private static readonly IValueConverter StyleConverter =
            Converters.FontStretchConverter.OrDefault(FontStretch.Normal);

        public FontStretchProperty()
            : base(PropertyNames.FontStretch, PropertyFlags.Inherited | PropertyFlags.Animatable)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}
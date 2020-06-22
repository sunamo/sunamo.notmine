
namespace ExCSS
{
    public sealed class FontSizeProperty : Property
    {
        private static readonly IValueConverter StyleConverter =
            Converters.FontSizeConverter.OrDefault(FontSize.Medium.ToLength());

        public FontSizeProperty()
            : base(PropertyNames.FontSize, PropertyFlags.Inherited | PropertyFlags.Unitless | PropertyFlags.Animatable)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}
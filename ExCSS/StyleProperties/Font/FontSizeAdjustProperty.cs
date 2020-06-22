
namespace ExCSS
{
    public sealed class FontSizeAdjustProperty : Property
    {
        private static readonly IValueConverter StyleConverter = Converters.OptionalNumberConverter.OrDefault();

        public FontSizeAdjustProperty()
            : base(PropertyNames.FontSizeAdjust, PropertyFlags.Inherited | PropertyFlags.Animatable)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}
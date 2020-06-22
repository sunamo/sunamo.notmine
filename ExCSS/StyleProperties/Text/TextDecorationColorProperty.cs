
namespace ExCSS
{
    public sealed class TextDecorationColorProperty : Property
    {
        private static readonly IValueConverter StyleConverter = Converters.ColorConverter.OrDefault(Color.Black);

        public TextDecorationColorProperty()
            : base(PropertyNames.TextDecorationColor, PropertyFlags.Animatable)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}


namespace ExCSS
{
    public sealed class TextShadowProperty : Property
    {
        private static readonly IValueConverter StyleConverter = Converters.MultipleShadowConverter.OrDefault();

        public TextShadowProperty()
            : base(PropertyNames.TextShadow, PropertyFlags.Inherited | PropertyFlags.Animatable)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}
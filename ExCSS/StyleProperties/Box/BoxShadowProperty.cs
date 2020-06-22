
namespace ExCSS
{
    public sealed class BoxShadowProperty : Property
    {
        private static readonly IValueConverter StyleConverter = Converters.MultipleShadowConverter.OrDefault();

        public BoxShadowProperty()
            : base(PropertyNames.BoxShadow, PropertyFlags.Animatable)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}
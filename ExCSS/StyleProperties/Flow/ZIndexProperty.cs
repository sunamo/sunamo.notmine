
namespace ExCSS
{
    public sealed class ZIndexProperty : Property
    {
        private static readonly IValueConverter StyleConverter = Converters.OptionalIntegerConverter.OrDefault();

        public ZIndexProperty()
            : base(PropertyNames.ZIndex, PropertyFlags.Animatable)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}
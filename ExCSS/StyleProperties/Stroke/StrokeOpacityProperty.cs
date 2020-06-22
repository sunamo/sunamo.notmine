
namespace ExCSS
{
    public sealed class StrokeOpacityProperty : Property
    {
        private static readonly IValueConverter StyleConverter = Converters.NumberConverter.OrDefault(1f);

        public StrokeOpacityProperty()
            : base(PropertyNames.StrokeOpacity, PropertyFlags.Animatable)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}
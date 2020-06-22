
namespace ExCSS
{
    public sealed class OpacityProperty : Property
    {
        private static readonly IValueConverter StyleConverter = Converters.NumberConverter.OrDefault(1f);

        public OpacityProperty()
            : base(PropertyNames.Opacity, PropertyFlags.Animatable)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}
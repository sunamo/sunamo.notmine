
namespace ExCSS
{
    public sealed class MaxHeightProperty : Property
    {
        private static readonly IValueConverter StyleConverter = Converters.OptionalLengthOrPercentConverter.OrDefault();

        public MaxHeightProperty()
            : base(PropertyNames.MaxHeight, PropertyFlags.Animatable)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}
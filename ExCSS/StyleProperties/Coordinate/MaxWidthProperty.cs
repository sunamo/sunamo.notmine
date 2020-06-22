
namespace ExCSS
{
    public sealed class MaxWidthProperty : Property
    {
        private static readonly IValueConverter StyleConverter = Converters.OptionalLengthOrPercentConverter.OrDefault();

        public MaxWidthProperty()
            : base(PropertyNames.MaxWidth, PropertyFlags.Animatable)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}
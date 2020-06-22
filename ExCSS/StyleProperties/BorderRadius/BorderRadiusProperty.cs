
namespace ExCSS
{
    public sealed class BorderRadiusProperty : ShorthandProperty
    {
        private static readonly IValueConverter StyleConverter = Converters.BorderRadiusShorthandConverter.OrDefault();

        public BorderRadiusProperty()
            : base(PropertyNames.BorderRadius, PropertyFlags.Animatable)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}
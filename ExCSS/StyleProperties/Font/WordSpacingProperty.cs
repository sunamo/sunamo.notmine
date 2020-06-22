
namespace ExCSS
{
    public sealed class WordSpacingProperty : Property
    {
        private static readonly IValueConverter StyleConverter = Converters.OptionalLengthConverter.OrDefault();

        public WordSpacingProperty()
            : base(
                PropertyNames.WordSpacing, PropertyFlags.Inherited | PropertyFlags.Unitless | PropertyFlags.Animatable)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}

namespace ExCSS
{
    public sealed class LetterSpacingProperty : Property
    {
        private static readonly IValueConverter StyleConverter = Converters.OptionalLengthConverter.OrDefault();

        public LetterSpacingProperty()
            : base(PropertyNames.LetterSpacing, PropertyFlags.Inherited | PropertyFlags.Unitless)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}

namespace ExCSS
{
    public sealed class TextIndentProperty : Property
    {
        private static readonly IValueConverter StyleConverter =
            Converters.LengthOrPercentConverter.OrDefault(Length.Zero);

        public TextIndentProperty()
            : base(PropertyNames.TextIndent, PropertyFlags.Inherited | PropertyFlags.Animatable)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}
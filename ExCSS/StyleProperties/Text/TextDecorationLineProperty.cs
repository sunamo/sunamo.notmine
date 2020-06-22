
namespace ExCSS
{
    public sealed class TextDecorationLineProperty : Property
    {
        private static readonly IValueConverter ListConverter = Converters.TextDecorationLinesConverter.OrDefault();

        public TextDecorationLineProperty()
            : base(PropertyNames.TextDecorationLine)
        {
        }

        public override IValueConverter Converter => ListConverter;
    }
}
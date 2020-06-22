
namespace ExCSS
{
    public sealed class WhiteSpaceProperty : Property
    {
        private static readonly IValueConverter StyleConverter =
            Converters.WhitespaceConverter.OrDefault(Whitespace.Normal);

        public WhiteSpaceProperty()
            : base(PropertyNames.WhiteSpace, PropertyFlags.Inherited)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}
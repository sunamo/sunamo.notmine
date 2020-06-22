
namespace ExCSS
{
    public sealed class BorderLeftStyleProperty : Property
    {
        private static readonly IValueConverter StyleConverter = Converters.LineStyleConverter.OrDefault(LineStyle.None);

        public BorderLeftStyleProperty()
            : base(PropertyNames.BorderLeftStyle)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}
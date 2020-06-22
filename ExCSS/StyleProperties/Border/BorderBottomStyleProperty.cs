
namespace ExCSS
{
    public sealed class BorderBottomStyleProperty : Property
    {
        private static readonly IValueConverter StyleConverter = Converters.LineStyleConverter.OrDefault(LineStyle.None);

        public BorderBottomStyleProperty()
            : base(PropertyNames.BorderBottomStyle)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}
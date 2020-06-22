
namespace ExCSS
{
    public sealed class BorderTopStyleProperty : Property
    {
        private static readonly IValueConverter StyleConverter = Converters.LineStyleConverter.OrDefault(LineStyle.None);

        public BorderTopStyleProperty()
            : base(PropertyNames.BorderTopStyle)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}

namespace ExCSS
{
    public sealed class BorderRightStyleProperty : Property
    {
        private static readonly IValueConverter StyleConverter = Converters.LineStyleConverter.OrDefault(LineStyle.None);

        public BorderRightStyleProperty()
            : base(PropertyNames.BorderRightStyle)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}
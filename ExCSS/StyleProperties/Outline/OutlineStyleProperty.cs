
namespace ExCSS
{
    public sealed class OutlineStyleProperty : Property
    {
        private static readonly IValueConverter StyleConverter = Converters.LineStyleConverter.OrDefault(LineStyle.None);

        public OutlineStyleProperty()
            : base(PropertyNames.OutlineStyle)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}
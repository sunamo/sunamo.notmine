
namespace ExCSS
{
    public sealed class ColumnRuleStyleProperty : Property
    {
        private static readonly IValueConverter StyleConverter = Converters.LineStyleConverter.OrDefault(LineStyle.None);

        public ColumnRuleStyleProperty()
            : base(PropertyNames.ColumnRuleStyle)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}
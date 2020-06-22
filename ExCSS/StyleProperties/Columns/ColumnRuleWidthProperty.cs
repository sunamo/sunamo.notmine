
namespace ExCSS
{
    public sealed class ColumnRuleWidthProperty : Property
    {
        private static readonly IValueConverter StyleConverter = Converters.LineWidthConverter.OrDefault(Length.Medium);

        public ColumnRuleWidthProperty()
            : base(PropertyNames.ColumnRuleWidth, PropertyFlags.Animatable)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}

namespace ExCSS
{
    public sealed class ColumnRuleColorProperty : Property
    {
        private static readonly IValueConverter StyleConverter = Converters.ColorConverter.OrDefault(Color.Transparent);

        public ColumnRuleColorProperty()
            : base(PropertyNames.ColumnRuleColor, PropertyFlags.Animatable)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}
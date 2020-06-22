
namespace ExCSS
{
    using static Converters;

    public sealed class ColumnRuleProperty : ShorthandProperty
    {
        private static readonly IValueConverter StyleConverter = WithAny(
            ColorConverter.Option().For(PropertyNames.ColumnRuleColor),
            LineWidthConverter.Option().For(PropertyNames.ColumnRuleWidth),
            LineStyleConverter.Option().For(PropertyNames.ColumnRuleStyle)).OrDefault();

        public ColumnRuleProperty()
            : base(PropertyNames.ColumnRule, PropertyFlags.Animatable)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}
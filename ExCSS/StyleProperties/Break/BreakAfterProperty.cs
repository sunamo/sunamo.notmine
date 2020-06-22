
namespace ExCSS
{
    public sealed class BreakAfterProperty : Property
    {
        private static readonly IValueConverter StyleConverter = Converters.BreakModeConverter.OrDefault(BreakMode.Auto);

        public BreakAfterProperty()
            : base(PropertyNames.BreakAfter)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}
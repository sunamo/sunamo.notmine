
namespace ExCSS
{
    public sealed class BreakBeforeProperty : Property
    {
        private static readonly IValueConverter StyleConverter = Converters.BreakModeConverter.OrDefault(BreakMode.Auto);

        public BreakBeforeProperty()
            : base(PropertyNames.BreakBefore)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}
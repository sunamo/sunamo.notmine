
namespace ExCSS
{
    public sealed class PageBreakBeforeProperty : Property
    {
        private static readonly IValueConverter StyleConverter =
            Converters.PageBreakModeConverter.OrDefault(BreakMode.Auto);

        public PageBreakBeforeProperty()
            : base(PropertyNames.PageBreakBefore)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}
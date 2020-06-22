
namespace ExCSS
{
    public sealed class PageBreakAfterProperty : Property
    {
        private static readonly IValueConverter StyleConverter =
            Converters.PageBreakModeConverter.OrDefault(BreakMode.Auto);

        public PageBreakAfterProperty()
            : base(PropertyNames.PageBreakAfter)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}
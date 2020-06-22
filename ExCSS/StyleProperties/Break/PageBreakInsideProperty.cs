
namespace ExCSS
{
    public sealed class PageBreakInsideProperty : Property
    {

        private static readonly IValueConverter StyleConverter =
            Converters.Assign(Keywords.Auto, BreakMode.Auto)
                .Or(Keywords.Avoid, BreakMode.Avoid)
                .OrDefault(BreakMode.Auto);

        public PageBreakInsideProperty()
            : base(PropertyNames.PageBreakInside)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}
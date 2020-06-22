
namespace ExCSS
{
    public sealed class BorderCollapseProperty : Property
    {
        private static readonly IValueConverter StyleConverter = Converters.BorderCollapseConverter.OrDefault(true);

        public BorderCollapseProperty()
            : base(PropertyNames.BorderCollapse, PropertyFlags.Inherited)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}
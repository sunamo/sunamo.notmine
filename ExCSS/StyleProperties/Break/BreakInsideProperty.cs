
namespace ExCSS
{
    public sealed class BreakInsideProperty : Property
    {
        private static readonly IValueConverter StyleConverter =
            Converters.BreakInsideModeConverter.OrDefault(BreakMode.Auto);

        public BreakInsideProperty()
            : base(PropertyNames.BreakInside)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}
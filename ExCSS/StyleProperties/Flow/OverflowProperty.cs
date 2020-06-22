
namespace ExCSS
{
    public sealed class OverflowProperty : Property
    {
        private static readonly IValueConverter StyleConverter =
            Converters.OverflowModeConverter.OrDefault(Overflow.Visible);

        public OverflowProperty()
            : base(PropertyNames.Overflow)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}
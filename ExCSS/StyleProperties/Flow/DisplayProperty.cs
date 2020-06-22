
namespace ExCSS
{
    public sealed class DisplayProperty : Property
    {
        private static readonly IValueConverter StyleConverter =
            Converters.DisplayModeConverter.OrDefault(DisplayMode.Inline);

        public DisplayProperty()
            : base(PropertyNames.Display)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}
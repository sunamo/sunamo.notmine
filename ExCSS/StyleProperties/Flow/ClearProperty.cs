
namespace ExCSS
{
    public sealed class ClearProperty : Property
    {
        private static readonly IValueConverter StyleConverter = Converters.ClearModeConverter.OrDefault(ClearMode.None);

        public ClearProperty()
            : base(PropertyNames.Clear)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}
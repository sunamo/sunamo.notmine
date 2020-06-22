
namespace ExCSS
{
    public sealed class CaptionSideProperty : Property
    {
        private static readonly IValueConverter StyleConverter = Converters.CaptionSideConverter.OrDefault(true);

        public CaptionSideProperty() : base(PropertyNames.CaptionSide)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}
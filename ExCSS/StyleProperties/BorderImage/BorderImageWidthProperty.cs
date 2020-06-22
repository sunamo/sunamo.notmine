
namespace ExCSS
{
    public sealed class BorderImageWidthProperty : Property
    {
        public static readonly IValueConverter TheConverter = Converters.ImageBorderWidthConverter.Periodic();
        private static readonly IValueConverter StyleConverter = TheConverter.OrDefault(Length.Full);

        public BorderImageWidthProperty()
            : base(PropertyNames.BorderImageWidth)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}

namespace ExCSS
{
    public sealed class BorderImageOutsetProperty : Property
    {
        public static readonly IValueConverter TheConverter = Converters.LengthOrPercentConverter.Periodic();
        private static readonly IValueConverter StyleConverter = TheConverter.OrDefault(Length.Zero);

        public BorderImageOutsetProperty()
            : base(PropertyNames.BorderImageOutset)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}
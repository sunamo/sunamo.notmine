
namespace ExCSS
{
    public sealed class PaddingProperty : ShorthandProperty
    {
        private static readonly IValueConverter StyleConverter = Converters.LengthOrPercentConverter.Periodic(
                PropertyNames.PaddingTop, PropertyNames.PaddingRight, PropertyNames.PaddingBottom, PropertyNames.PaddingLeft)
            .OrDefault(Length.Zero);

        public PaddingProperty()
            : base(PropertyNames.Padding)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}
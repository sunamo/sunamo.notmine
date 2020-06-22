
namespace ExCSS
{
    public sealed class MarginProperty : ShorthandProperty
    {
        private static readonly IValueConverter StyleConverter = Converters.AutoLengthOrPercentConverter.Periodic(
                PropertyNames.MarginTop, PropertyNames.MarginRight, PropertyNames.MarginBottom, PropertyNames.MarginLeft)
            .OrDefault(Length.Zero);

        public MarginProperty()
            : base(PropertyNames.Margin)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}
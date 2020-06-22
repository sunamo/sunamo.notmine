
namespace ExCSS
{
    public sealed class BorderColorProperty : ShorthandProperty
    {
        private static readonly IValueConverter StyleConverter = Converters.CurrentColorConverter.Periodic(
            PropertyNames.BorderTopColor, PropertyNames.BorderRightColor, PropertyNames.BorderBottomColor,
            PropertyNames.BorderLeftColor).OrDefault();

        public BorderColorProperty()
            : base(PropertyNames.BorderColor, PropertyFlags.Hashless | PropertyFlags.Animatable)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}

namespace ExCSS
{
    public sealed class PaddingRightProperty : Property
    {
        private static readonly IValueConverter StyleConverter =
            Converters.LengthOrPercentConverter.OrDefault(Length.Zero);

        public PaddingRightProperty()
            : base(PropertyNames.PaddingRight, PropertyFlags.Unitless | PropertyFlags.Animatable)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}
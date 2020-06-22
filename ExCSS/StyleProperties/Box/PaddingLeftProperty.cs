
namespace ExCSS
{
    public sealed class PaddingLeftProperty : Property
    {
        private static readonly IValueConverter StyleConverter =
            Converters.LengthOrPercentConverter.OrDefault(Length.Zero);

        public PaddingLeftProperty()
            : base(PropertyNames.PaddingLeft, PropertyFlags.Unitless | PropertyFlags.Animatable)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}

namespace ExCSS
{
    public sealed class PaddingTopProperty : Property
    {
        private static readonly IValueConverter StyleConverter =
            Converters.LengthOrPercentConverter.OrDefault(Length.Zero);

        public PaddingTopProperty()
            : base(PropertyNames.PaddingTop, PropertyFlags.Unitless | PropertyFlags.Animatable)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}
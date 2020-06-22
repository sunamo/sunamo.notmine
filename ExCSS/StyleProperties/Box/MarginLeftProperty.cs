
namespace ExCSS
{
    public sealed class MarginLeftProperty : Property
    {
        private static readonly IValueConverter StyleConverter = Converters.AutoLengthOrPercentConverter.OrDefault(Length.Zero);

        public MarginLeftProperty()
            : base(PropertyNames.MarginLeft, PropertyFlags.Unitless | PropertyFlags.Animatable)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}
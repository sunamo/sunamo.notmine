
namespace ExCSS
{
    public sealed class MarginTopProperty : Property
    {
        private static readonly IValueConverter StyleConverter =
            Converters.AutoLengthOrPercentConverter.OrDefault(Length.Zero);
        
        public MarginTopProperty()
            : base(PropertyNames.MarginTop, PropertyFlags.Unitless | PropertyFlags.Animatable)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}

namespace ExCSS
{
    public sealed class MarginBottomProperty : Property
    {
        private static readonly IValueConverter StyleConverter =
            Converters.AutoLengthOrPercentConverter.OrDefault(Length.Zero);

        public MarginBottomProperty()
            : base(PropertyNames.MarginBottom, PropertyFlags.Unitless | PropertyFlags.Animatable)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}
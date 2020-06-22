
namespace ExCSS
{
    public sealed class MinHeightProperty : Property
    {
        private static readonly IValueConverter StyleConverter =
            Converters.LengthOrPercentConverter.OrDefault(Length.Zero);

        public MinHeightProperty()
            : base(PropertyNames.MinHeight, PropertyFlags.Animatable)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}

namespace ExCSS
{
    public sealed class TopProperty : Property
    {
        private static readonly IValueConverter StyleConverter =
            Converters.AutoLengthOrPercentConverter.OrDefault(Keywords.Auto);

        public TopProperty()
            : base(PropertyNames.Top, PropertyFlags.Unitless | PropertyFlags.Animatable)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}
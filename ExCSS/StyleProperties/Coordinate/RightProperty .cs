
namespace ExCSS
{
    public sealed class RightProperty : Property
    {
        private static readonly IValueConverter StyleConverter =
            Converters.AutoLengthOrPercentConverter.OrDefault(Keywords.Auto);
        
        public RightProperty()
            : base(PropertyNames.Right, PropertyFlags.Unitless | PropertyFlags.Animatable)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}
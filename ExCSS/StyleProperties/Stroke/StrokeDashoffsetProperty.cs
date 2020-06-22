
namespace ExCSS
{
    public sealed class StrokeDashoffsetProperty : Property
    {
        private static readonly IValueConverter StyleConverter = Converters.LengthOrPercentConverter;

        public StrokeDashoffsetProperty()
            : base(PropertyNames.StrokeDashoffset, PropertyFlags.Animatable)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}
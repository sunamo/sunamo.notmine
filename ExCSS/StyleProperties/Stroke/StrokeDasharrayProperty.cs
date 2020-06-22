
namespace ExCSS
{
    public sealed class StrokeDasharrayProperty : Property
    {
        private static readonly IValueConverter StyleConverter = Converters.StrokeDasharrayConverter;

        public StrokeDasharrayProperty()
            : base(PropertyNames.StrokeDasharray, PropertyFlags.Animatable | PropertyFlags.Unitless)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}
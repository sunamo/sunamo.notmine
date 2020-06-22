
namespace ExCSS
{
    public sealed class StrokeLinecapProperty : Property
    {
        private static readonly IValueConverter StyleConverter =
            Converters.StrokeLinecapConverter.OrDefault(StrokeLinecap.Butt);

        public StrokeLinecapProperty()
            : base(PropertyNames.StrokeLinecap, PropertyFlags.Animatable)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}

namespace ExCSS
{
    public sealed class StrokeProperty : Property
    {
        private static readonly IValueConverter StyleConverter = Converters.PaintConverter;

        public StrokeProperty()
            : base(PropertyNames.Stroke, PropertyFlags.Animatable)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}
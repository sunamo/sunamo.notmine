
namespace ExCSS
{
    public sealed class StrokeWidthProperty : Property
    {
        private static readonly IValueConverter StyleConverter = Converters.LengthOrPercentConverter;

        public StrokeWidthProperty()
            : base(PropertyNames.StrokeWidth, PropertyFlags.Animatable)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}
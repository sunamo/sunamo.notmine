
namespace ExCSS
{
    public sealed class StrokeLinejoinProperty : Property
    {
        private static readonly IValueConverter StyleConverter = Converters.StrokeLinejoinConverter;

        public StrokeLinejoinProperty()
            : base(PropertyNames.StrokeLinejoin, PropertyFlags.Animatable)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}
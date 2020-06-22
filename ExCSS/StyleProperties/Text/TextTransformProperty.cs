
namespace ExCSS
{
    public sealed class TextTransformProperty : Property
    {
        private static readonly IValueConverter StyleConverter =
            Converters.TextTransformConverter.OrDefault(TextTransform.None);

        public TextTransformProperty()
            : base(PropertyNames.TextTransform, PropertyFlags.Inherited)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}
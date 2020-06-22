
namespace ExCSS
{
    public sealed class TextAnchorProperty : Property
    {
        private static readonly IValueConverter StyleConverter = Converters.TextAnchorConverter;

        public TextAnchorProperty()
            : base(PropertyNames.TextAnchor)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}
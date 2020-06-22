
namespace ExCSS
{
    public sealed class TextJustifyProperty : Property
    {
        private static readonly IValueConverter StyleConverter = Converters.TextJustifyConverter;

        public TextJustifyProperty()
            : base(PropertyNames.TextJustify)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}
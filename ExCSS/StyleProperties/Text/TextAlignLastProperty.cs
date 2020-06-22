
namespace ExCSS
{
    public sealed class TextAlignLastProperty : Property
    {
        private static readonly IValueConverter StyleConverter = Converters.TextAlignLastConverter;

        public TextAlignLastProperty()
            : base(PropertyNames.TextAlignLast)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}
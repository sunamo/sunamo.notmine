
namespace ExCSS
{
    public sealed class TextAlignProperty : Property
    {
        private static readonly IValueConverter StyleConverter =
            Converters.HorizontalAlignmentConverter.OrDefault(HorizontalAlignment.Left);

        public TextAlignProperty()
            : base(PropertyNames.TextAlign, PropertyFlags.Inherited)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}
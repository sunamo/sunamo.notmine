
namespace ExCSS
{
    public sealed class BorderImageSourceProperty : Property
    {
        private static readonly IValueConverter StyleConverter = Converters.OptionalImageSourceConverter.OrDefault();

        public BorderImageSourceProperty()
            : base(PropertyNames.BorderImageSource)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}
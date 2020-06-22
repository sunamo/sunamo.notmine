
namespace ExCSS
{
    public sealed class BackgroundImageProperty : Property
    {
        private static readonly IValueConverter StyleConverter = Converters.MultipleImageSourceConverter.OrDefault();

        public BackgroundImageProperty()
            : base(PropertyNames.BackgroundImage)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}
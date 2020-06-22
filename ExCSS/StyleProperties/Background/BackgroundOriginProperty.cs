
namespace ExCSS
{
    public sealed class BackgroundOriginProperty : Property
    {
        private static readonly IValueConverter ListConverter =
            Converters.BoxModelConverter.FromList().OrDefault(BoxModel.PaddingBox);

        public BackgroundOriginProperty()
            : base(PropertyNames.BackgroundOrigin)
        {
        }

        public override IValueConverter Converter => ListConverter;
    }
}
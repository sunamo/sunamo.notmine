
namespace ExCSS
{
    public sealed class BackgroundClipProperty : Property
    {
        private static readonly IValueConverter ListConverter =
            Converters.BoxModelConverter.FromList().OrDefault(BoxModel.BorderBox);

        public BackgroundClipProperty()
            : base(PropertyNames.BackgroundClip)
        {
        }

        public override IValueConverter Converter => ListConverter;
    }
}
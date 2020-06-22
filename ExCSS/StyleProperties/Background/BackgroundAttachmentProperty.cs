
namespace ExCSS
{
    public sealed class BackgroundAttachmentProperty : Property
    {
        private static readonly IValueConverter AttachmentConverter =
            Converters.BackgroundAttachmentConverter.FromList().OrDefault(BackgroundAttachment.Scroll);

        public BackgroundAttachmentProperty()
            : base(PropertyNames.BackgroundAttachment)
        {
        }

        public override IValueConverter Converter => AttachmentConverter;
    }
}
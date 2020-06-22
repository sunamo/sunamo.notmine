
namespace ExCSS
{
    public sealed class TransformStyleProperty : Property
    {
        private static readonly IValueConverter StyleConverter =
            Converters.Toggle(Keywords.Flat, Keywords.Preserve3d).OrDefault(true);

        public TransformStyleProperty()
            : base(PropertyNames.TransformStyle)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}
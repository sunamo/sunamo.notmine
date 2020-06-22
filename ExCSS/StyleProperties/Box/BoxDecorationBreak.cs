
namespace ExCSS
{
    public sealed class BoxDecorationBreak : Property
    {
        private static readonly IValueConverter StyleConverter = Converters.BoxDecorationConverter.OrDefault(false);

        public BoxDecorationBreak()
            : base(PropertyNames.BoxDecorationBreak)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}
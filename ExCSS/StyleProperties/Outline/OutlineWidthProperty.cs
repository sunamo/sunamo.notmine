
namespace ExCSS
{
    public sealed class OutlineWidthProperty : Property
    {
        private static readonly IValueConverter StyleConverter = Converters.LineWidthConverter.OrDefault(Length.Medium);

        public OutlineWidthProperty()
            : base(PropertyNames.OutlineWidth, PropertyFlags.Animatable)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}

namespace ExCSS
{
    public sealed class OutlineColorProperty : Property
    {
        private static readonly IValueConverter StyleConverter =
            Converters.InvertedColorConverter.OrDefault(Color.Transparent);

        public OutlineColorProperty()
            : base(PropertyNames.OutlineColor, PropertyFlags.Animatable)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}
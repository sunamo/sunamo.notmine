
namespace ExCSS
{
    public sealed class ColorProperty : Property
    {
        private static readonly IValueConverter StyleConverter = Converters.ColorConverter.OrDefault(Color.Black);

        public ColorProperty()
            : base(PropertyNames.Color, PropertyFlags.Inherited | PropertyFlags.Hashless | PropertyFlags.Animatable)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}
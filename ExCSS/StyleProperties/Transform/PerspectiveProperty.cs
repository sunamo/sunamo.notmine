
namespace ExCSS
{
    public sealed class PerspectiveProperty : Property
    {
        private static readonly IValueConverter StyleConverter =
            Converters.LengthConverter.OrNone().OrDefault(Length.Zero);

        public PerspectiveProperty()
            : base(PropertyNames.Perspective, PropertyFlags.Animatable)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}
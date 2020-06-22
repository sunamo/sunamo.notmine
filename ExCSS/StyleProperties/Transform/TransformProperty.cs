
namespace ExCSS
{
    public sealed class TransformProperty : Property
    {
        private static readonly IValueConverter StyleConverter =
            Converters.TransformConverter.Many().OrNone().OrDefault();

        public TransformProperty()
            : base(PropertyNames.Transform, PropertyFlags.Animatable)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}
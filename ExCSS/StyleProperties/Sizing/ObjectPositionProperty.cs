
namespace ExCSS
{
    public sealed class ObjectPositionProperty : Property
    {
        private static readonly IValueConverter StyleConverter = Converters.PointConverter.OrDefault(Point.Center);

        public ObjectPositionProperty()
            : base(PropertyNames.ObjectPosition, PropertyFlags.Animatable)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}
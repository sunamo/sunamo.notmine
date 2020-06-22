
namespace ExCSS
{
    public sealed class BackgroundPositionProperty : Property
    {
        private static readonly IValueConverter ListConverter =
            Converters.PointConverter.FromList().OrDefault(Point.Center);

        public BackgroundPositionProperty()
            : base(PropertyNames.BackgroundPosition, PropertyFlags.Animatable)
        {
        }

        public override IValueConverter Converter => ListConverter;
    }
}
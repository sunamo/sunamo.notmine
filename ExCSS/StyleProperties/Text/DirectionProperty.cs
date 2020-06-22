
namespace ExCSS
{
    public sealed class DirectionProperty : Property
    {
        private static readonly IValueConverter StyleConverter =
            Converters.DirectionModeConverter.OrDefault(DirectionMode.Ltr);

        public DirectionProperty()
            : base(PropertyNames.Direction, PropertyFlags.Inherited)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}
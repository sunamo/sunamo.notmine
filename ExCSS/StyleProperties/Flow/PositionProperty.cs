
namespace ExCSS
{
    public sealed class PositionProperty : Property
    {
        private static readonly IValueConverter StyleConverter =
            Converters.PositionModeConverter.OrDefault(PositionMode.Static);

        public PositionProperty()
            : base(PropertyNames.Position)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}
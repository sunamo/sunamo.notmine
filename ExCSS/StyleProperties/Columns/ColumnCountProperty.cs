
namespace ExCSS
{
    public sealed class ColumnCountProperty : Property
    {
        private static readonly IValueConverter StyleConverter = Converters.OptionalIntegerConverter.OrDefault();

        public ColumnCountProperty()
            : base(PropertyNames.ColumnCount, PropertyFlags.Animatable)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}
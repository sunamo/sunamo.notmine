
namespace ExCSS
{
    public sealed class WidowsProperty : Property
    {
        private static readonly IValueConverter StyleConverter = Converters.IntegerConverter.OrDefault(2);

        public WidowsProperty()
            : base(PropertyNames.Widows, PropertyFlags.Inherited)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}
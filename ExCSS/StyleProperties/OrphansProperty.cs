
namespace ExCSS
{
    public sealed class OrphansProperty : Property
    {
        private static readonly IValueConverter StyleConverter = Converters.NaturalIntegerConverter.OrDefault(2);

        public OrphansProperty()
            : base(PropertyNames.Orphans, PropertyFlags.Inherited)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}
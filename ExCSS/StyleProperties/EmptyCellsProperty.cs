
namespace ExCSS
{
    public sealed class EmptyCellsProperty : Property
    {
        private static readonly IValueConverter StyleConverter = Converters.EmptyCellsConverter.OrDefault(true);

        public EmptyCellsProperty()
            : base(PropertyNames.EmptyCells, PropertyFlags.Inherited)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}
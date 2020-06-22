
namespace ExCSS
{
    using static Converters;

    public sealed class CounterIncrementProperty : Property
    {
        private static readonly IValueConverter StyleConverter = Continuous(
            WithOrder(IdentifierConverter.Required(), IntegerConverter.Option(1))).OrDefault();

        public CounterIncrementProperty()
            : base(PropertyNames.CounterIncrement)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}
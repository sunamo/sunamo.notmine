
namespace ExCSS
{
    using static Converters;

    public sealed class CounterResetProperty : Property
    {
        private static readonly IValueConverter StyleConverter = Continuous(
            WithOrder(IdentifierConverter.Required(), IntegerConverter.Option(0))).OrDefault();

        public CounterResetProperty()
            : base(PropertyNames.CounterReset)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}
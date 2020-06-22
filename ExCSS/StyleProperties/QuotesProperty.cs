
namespace ExCSS
{
    public sealed class QuotesProperty : Property
    {
        private static readonly IValueConverter StyleConverter =
            Converters.EvenStringsConverter.OrNone().OrDefault(new[] {"«", "»"});

        public QuotesProperty()
            : base(PropertyNames.Quotes, PropertyFlags.Inherited)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}
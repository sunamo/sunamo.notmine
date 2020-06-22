
namespace ExCSS
{
    public sealed class UnicodeRangeProperty : Property
    {
        public UnicodeRangeProperty()
            : base(PropertyNames.UnicodeRange)
        {
        }

        public override IValueConverter Converter => Converters.Any;
    }
}
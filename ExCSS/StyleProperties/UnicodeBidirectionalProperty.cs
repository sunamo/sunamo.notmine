
namespace ExCSS
{
    public sealed class UnicodeBidirectionalProperty : Property
    {
        private static readonly IValueConverter StyleConverter =
            Converters.UnicodeModeConverter.OrDefault(UnicodeMode.Normal);

        public UnicodeBidirectionalProperty()
            : base(PropertyNames.UnicodeBidirectional)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}
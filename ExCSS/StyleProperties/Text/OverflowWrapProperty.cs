
namespace ExCSS
{
    public sealed class OverflowWrapProperty : Property
    {
        private static readonly IValueConverter StyleConverter = Converters.OverflowWrapConverter;

        public OverflowWrapProperty()
            : base(PropertyNames.OverflowWrap)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}
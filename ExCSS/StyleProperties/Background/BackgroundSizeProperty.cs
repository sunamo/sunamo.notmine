
namespace ExCSS
{
    public sealed class BackgroundSizeProperty : Property
    {
        private static readonly IValueConverter ListConverter =
            Converters.BackgroundSizeConverter.FromList().OrDefault();

        public BackgroundSizeProperty()
            : base(PropertyNames.BackgroundSize, PropertyFlags.Animatable)
        {
        }

        public override IValueConverter Converter => ListConverter;
    }
}

namespace ExCSS
{
    public sealed class BackgroundRepeatProperty : Property
    {
        private static readonly IValueConverter ListConverter =
            Converters.BackgroundRepeatsConverter.FromList().OrDefault(BackgroundRepeat.Repeat);

        public BackgroundRepeatProperty()
            : base(PropertyNames.BackgroundRepeat)
        {
        }

        public override IValueConverter Converter => ListConverter;
    }
}
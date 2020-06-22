
namespace ExCSS
{
    public sealed class TransitionTimingFunctionProperty : Property
    {
        private static readonly IValueConverter ListConverter =
            Converters.TransitionConverter.FromList().OrDefault(Map.TimingFunctions[Keywords.Ease]);

        public TransitionTimingFunctionProperty()
            : base(PropertyNames.TransitionTimingFunction)
        {
        }

        public override IValueConverter Converter => ListConverter;
    }
}
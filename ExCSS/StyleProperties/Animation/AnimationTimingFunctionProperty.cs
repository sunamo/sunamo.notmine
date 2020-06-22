
namespace ExCSS
{
    public sealed class AnimationTimingFunctionProperty : Property
    {
        private static readonly IValueConverter ListConverter =
            Converters.TransitionConverter.FromList().OrDefault(Map.TimingFunctions[Keywords.Ease]);

        public AnimationTimingFunctionProperty()
            : base(PropertyNames.AnimationTimingFunction)
        {
        }

        public override IValueConverter Converter => ListConverter;
    }
}

namespace ExCSS
{
    public sealed class AnimationIterationCountProperty : Property
    {
        private static readonly IValueConverter ListConverter =
            Converters.PositiveOrInfiniteNumberConverter.FromList().OrDefault(1f);

        public AnimationIterationCountProperty()
            : base(PropertyNames.AnimationIterationCount)
        {
        }

        public override IValueConverter Converter => ListConverter;
    }
}
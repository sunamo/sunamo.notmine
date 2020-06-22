
namespace ExCSS
{
    using static Converters;

    public sealed class AnimationProperty : ShorthandProperty
    {

        private static readonly IValueConverter ListConverter = WithAny(
            TimeConverter.Option().For(PropertyNames.AnimationDuration),
            TransitionConverter.Option().For(PropertyNames.AnimationTimingFunction),
            TimeConverter.Option().For(PropertyNames.AnimationDelay),
            PositiveOrInfiniteNumberConverter.Option().For(PropertyNames.AnimationIterationCount),
            AnimationDirectionConverter.Option().For(PropertyNames.AnimationDirection),
            AnimationFillStyleConverter.Option().For(PropertyNames.AnimationFillMode),
            PlayStateConverter.Option().For(PropertyNames.AnimationPlayState),
            IdentifierConverter.Option().For(PropertyNames.AnimationName)).FromList().OrDefault();

        public AnimationProperty() : base(PropertyNames.Animation)
        {
        }

        public override IValueConverter Converter => ListConverter;
    }
}
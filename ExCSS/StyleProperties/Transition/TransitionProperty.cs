
namespace ExCSS
{
    using static Converters;

    public sealed class TransitionProperty : ShorthandProperty
    {
        public static readonly IValueConverter ListConverter = WithAny(
            AnimatableConverter.Option().For(PropertyNames.TransitionProperty),
            TimeConverter.Option().For(PropertyNames.TransitionDuration),
            TransitionConverter.Option().For(PropertyNames.TransitionTimingFunction),
            TimeConverter.Option().For(PropertyNames.TransitionDelay)).FromList().OrDefault();

        public TransitionProperty()
            : base(PropertyNames.Transition)
        {
        }

        public override IValueConverter Converter => ListConverter;
    }
}

namespace ExCSS
{
    public sealed class TransitionDelayProperty : Property
    {
        private static readonly IValueConverter ListConverter = Converters.TimeConverter.FromList().OrDefault(Time.Zero);

        public TransitionDelayProperty()
            : base(PropertyNames.TransitionDelay)
        {
        }

        public override IValueConverter Converter => ListConverter;
    }
}
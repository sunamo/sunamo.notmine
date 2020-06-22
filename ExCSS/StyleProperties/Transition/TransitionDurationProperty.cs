
namespace ExCSS
{
    public sealed class TransitionDurationProperty : Property
    {
        private static readonly IValueConverter ListConverter = Converters.TimeConverter.FromList().OrDefault(Time.Zero);

        public TransitionDurationProperty()
            : base(PropertyNames.TransitionDuration)
        {
        }

        public override IValueConverter Converter => ListConverter;
    }
}
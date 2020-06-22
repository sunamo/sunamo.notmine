
namespace ExCSS
{
    public sealed class AnimationDelayProperty : Property
    {
        private static readonly IValueConverter ListConverter = Converters.TimeConverter.FromList().OrDefault(Time.Zero);

        public AnimationDelayProperty()
            : base(PropertyNames.AnimationDelay)
        {
        }

        public override IValueConverter Converter => ListConverter;
    }
}

namespace ExCSS
{
    sealed class AnimationDurationProperty : Property
    {
        private static readonly IValueConverter ListConverter = Converters.TimeConverter.FromList().OrDefault(Time.Zero);

        public AnimationDurationProperty() : base(PropertyNames.AnimationDuration)
        {
        }

        public override IValueConverter Converter => ListConverter;
    }
}

namespace ExCSS
{
    public sealed class AnimationFillModeProperty : Property
    {
        private static readonly IValueConverter ListConverter =
            Converters.AnimationFillStyleConverter.FromList().OrDefault(AnimationFillStyle.None);

        public AnimationFillModeProperty()
            : base(PropertyNames.AnimationFillMode)
        {
        }

        public override IValueConverter Converter => ListConverter;
    }
}

namespace ExCSS
{
    public sealed class AnimationDirectionProperty : Property
    {
        private static readonly IValueConverter ListConverter =
            Converters.AnimationDirectionConverter.FromList().OrDefault(AnimationDirection.Normal);

        public AnimationDirectionProperty()
            : base(PropertyNames.AnimationDirection)
        {
        }

        public override IValueConverter Converter => ListConverter;
    }
}
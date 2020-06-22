
namespace ExCSS
{
    public sealed class AnimationPlayStateProperty : Property
    {
        private static readonly IValueConverter ListConverter =
            Converters.PlayStateConverter.FromList().OrDefault(PlayState.Running);

        public AnimationPlayStateProperty()
            : base(PropertyNames.AnimationPlayState)
        {
        }

        public override IValueConverter Converter => ListConverter;
    }
}
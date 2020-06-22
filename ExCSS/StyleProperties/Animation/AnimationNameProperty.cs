
namespace ExCSS
{
    public sealed class AnimationNameProperty : Property
    {
        private static readonly IValueConverter ListConverter =
            Converters.IdentifierConverter.FromList().OrNone().OrDefault();

        public AnimationNameProperty()
            : base(PropertyNames.AnimationName)
        {
        }

        public override IValueConverter Converter => ListConverter;
    }
}
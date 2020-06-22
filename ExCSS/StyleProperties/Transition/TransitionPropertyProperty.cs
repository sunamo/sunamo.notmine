
namespace ExCSS
{
    public sealed class TransitionPropertyProperty : Property
    {
        private static readonly IValueConverter ListConverter =
            Converters.AnimatableConverter.FromList().OrNone().OrDefault(Keywords.All);

        public TransitionPropertyProperty()
            : base(PropertyNames.TransitionProperty)
        {
        }

        public override IValueConverter Converter => ListConverter;
    }
}
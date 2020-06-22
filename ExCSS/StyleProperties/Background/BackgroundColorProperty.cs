
namespace ExCSS
{
    public sealed class BackgroundColorProperty : Property
    {
        private static readonly IValueConverter StyleConverter = Converters.CurrentColorConverter.OrDefault();

        public BackgroundColorProperty()
            : base(PropertyNames.BackgroundColor, PropertyFlags.Hashless | PropertyFlags.Animatable)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}
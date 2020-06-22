
namespace ExCSS
{
    public sealed class BackfaceVisibilityProperty : Property
    {
        private static readonly IValueConverter StyleConverter = Converters.BackfaceVisibilityConverter.OrDefault(true);

        public BackfaceVisibilityProperty()
            : base(PropertyNames.BackfaceVisibility)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}
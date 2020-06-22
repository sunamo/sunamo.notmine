
namespace ExCSS
{
    public sealed class VisibilityProperty : Property
    {
        private static readonly IValueConverter StyleConverter =
            Converters.VisibilityConverter.OrDefault(Visibility.Visible);

        public VisibilityProperty()
            : base(PropertyNames.Visibility, PropertyFlags.Inherited | PropertyFlags.Animatable)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}
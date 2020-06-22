
namespace ExCSS
{
    public sealed class LineHeightProperty : Property
    {
        private static readonly IValueConverter StyleConverter =
            Converters.LineHeightConverter.OrDefault(new Length(120f, Length.Unit.Percent));

        public LineHeightProperty()
            : base(PropertyNames.LineHeight, PropertyFlags.Inherited | PropertyFlags.Animatable)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}
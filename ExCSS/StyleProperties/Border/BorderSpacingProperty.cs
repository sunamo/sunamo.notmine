
namespace ExCSS
{
    public sealed class BorderSpacingProperty : Property
    {
        private static readonly IValueConverter StyleConverter =
            Converters.LengthConverter.Many(1, 2).OrDefault(Length.Zero);

        public BorderSpacingProperty()
            : base(PropertyNames.BorderSpacing, PropertyFlags.Inherited)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}
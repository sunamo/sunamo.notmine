
namespace ExCSS
{
    using static Converters;

    public sealed class VerticalAlignProperty : Property
    {
        private static readonly IValueConverter StyleConverter = LengthOrPercentConverter.Or(
            VerticalAlignmentConverter).OrDefault(VerticalAlignment.Baseline);

        public VerticalAlignProperty()
            : base(PropertyNames.VerticalAlign, PropertyFlags.Animatable)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}

namespace ExCSS
{
    public sealed class ColumnGapProperty : Property
    {
        private static readonly IValueConverter StyleConverter =
            Converters.LengthOrNormalConverter.OrDefault(new Length(1f, Length.Unit.Em));

        public ColumnGapProperty()
            : base(PropertyNames.ColumnGap, PropertyFlags.Animatable)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}
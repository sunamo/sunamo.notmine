
namespace ExCSS
{
    public sealed class BorderTopColorProperty : Property
    {
        private static readonly IValueConverter StyleConverter =
            Converters.CurrentColorConverter.OrDefault(Color.Transparent);
       
        public BorderTopColorProperty()
            : base(PropertyNames.BorderTopColor)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}
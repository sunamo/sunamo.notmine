
namespace ExCSS
{
    using static Converters;

    public sealed class CursorProperty : Property
    {
        private static readonly IValueConverter StyleConverter = ImageSourceConverter.Or(
            WithOrder(
                ImageSourceConverter.Required(),
                NumberConverter.Required(),
                NumberConverter.Required())).RequiresEnd(
            Map.Cursors.ToConverter()).OrDefault(SystemCursor.Auto);

        public CursorProperty()
            : base(PropertyNames.Cursor, PropertyFlags.Inherited)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}
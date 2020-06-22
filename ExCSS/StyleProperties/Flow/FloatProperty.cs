
namespace ExCSS
{
    public sealed class FloatProperty : Property
    {
        private static readonly IValueConverter StyleConverter = Converters.FloatingConverter.OrDefault(Floating.None);

        public FloatProperty()
            : base(PropertyNames.Float)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}

namespace ExCSS
{
    public sealed class ClipProperty : Property
    {
        private static readonly IValueConverter StyleConverter = Converters.ShapeConverter.OrDefault();

        public ClipProperty()
            : base(PropertyNames.Clip, PropertyFlags.Animatable)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}
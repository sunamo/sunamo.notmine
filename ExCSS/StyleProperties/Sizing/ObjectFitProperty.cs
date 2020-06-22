
namespace ExCSS
{
    public sealed class ObjectFitProperty : Property
    {
        private static readonly IValueConverter StyleConverter =
            Converters.ObjectFittingConverter.OrDefault(ObjectFitting.Fill);

        public ObjectFitProperty()
            : base(PropertyNames.ObjectFit)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}

namespace ExCSS
{
    public sealed class SrcProperty : Property
    {
        public SrcProperty()
            : base(PropertyNames.Src)
        {
        }

        public override IValueConverter Converter => Converters.Any;
    }
}
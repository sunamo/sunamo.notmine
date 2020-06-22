
namespace ExCSS
{
    public sealed class UnknownProperty : Property
    {
        public UnknownProperty(string name)
            : base(name)
        {
        }

        public override IValueConverter Converter => Converters.Any;
    }
}
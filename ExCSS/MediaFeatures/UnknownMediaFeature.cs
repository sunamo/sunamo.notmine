
namespace ExCSS
{
    public sealed class UnknownMediaFeature : MediaFeature
    {
        public UnknownMediaFeature(string name)
            : base(name)
        {
        }

        public override IValueConverter Converter => Converters.Any;

    }
}
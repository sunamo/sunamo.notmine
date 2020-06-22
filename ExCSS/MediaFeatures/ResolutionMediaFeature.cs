
namespace ExCSS
{
    public sealed class ResolutionMediaFeature : MediaFeature
    {

        public ResolutionMediaFeature(string name)
            : base(name)
        {
        }

        public override IValueConverter Converter => Converters.ResolutionConverter;

    }
}

namespace ExCSS
{
    public sealed class DevicePixelRatioFeature : MediaFeature
    {
        public DevicePixelRatioFeature(string name)
            : base(name)
        {
        }

        public override IValueConverter Converter => Converters.NaturalNumberConverter;

    }
}
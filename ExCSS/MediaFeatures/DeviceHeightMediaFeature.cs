
namespace ExCSS
{
    public sealed class DeviceHeightMediaFeature : MediaFeature
    {
        public DeviceHeightMediaFeature(string name)
            : base(name)
        {
        }

        public override IValueConverter Converter => Converters.LengthConverter;

    }
}
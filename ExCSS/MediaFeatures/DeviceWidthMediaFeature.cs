
namespace ExCSS
{
    public sealed class DeviceWidthMediaFeature : MediaFeature
    {
        public DeviceWidthMediaFeature(string name)
            : base(name)
        {
        }

        public override IValueConverter Converter => Converters.LengthConverter;

    }
}
using System;

namespace ExCSS
{
    public sealed class DeviceAspectRatioMediaFeature : MediaFeature
    {
        public DeviceAspectRatioMediaFeature(string name)
            : base(name)
        {
        }

        public override IValueConverter Converter => Converters.RatioConverter;

    }
}
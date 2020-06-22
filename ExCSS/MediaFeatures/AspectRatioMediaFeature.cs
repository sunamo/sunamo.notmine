using System;

namespace ExCSS
{
    public sealed class AspectRatioMediaFeature : MediaFeature
    {
        public AspectRatioMediaFeature(string name) : base(name)
        {
        }

        public override IValueConverter Converter => Converters.RatioConverter;

    }
}
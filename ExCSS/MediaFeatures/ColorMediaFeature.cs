using System;

namespace ExCSS
{
    using static Converters;

    public sealed class ColorMediaFeature : MediaFeature
    {
        public ColorMediaFeature(string name) : base(name)
        {
        }

        public override IValueConverter Converter => 
            IsMinimum || IsMaximum 
            ? PositiveIntegerConverter
            : PositiveIntegerConverter.Option(1);

    }
}
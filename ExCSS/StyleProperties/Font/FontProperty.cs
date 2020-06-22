
namespace ExCSS
{
    using static Converters;

    public sealed class FontProperty : ShorthandProperty
    {
        private static readonly IValueConverter StyleConverter = WithOrder(
            WithAny(
                FontStyleConverter.Option().For(PropertyNames.FontStyle),
                FontVariantConverter.Option().For(PropertyNames.FontVariant),
                FontWeightConverter.Or(WeightIntegerConverter).Option().For(PropertyNames.FontWeight),
                FontStretchConverter.Option().For(PropertyNames.FontStretch)),
            WithOrder(
                FontSizeConverter.Required().For(PropertyNames.FontSize),
                LineHeightConverter.StartsWithDelimiter().Option().For(PropertyNames.LineHeight),
                FontFamiliesConverter.Required().For(PropertyNames.FontFamily))).Or(
            SystemFontConverter);

        public FontProperty()
            : base(PropertyNames.Font, PropertyFlags.Inherited | PropertyFlags.Animatable)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}

namespace ExCSS
{
    using static Converters;

    public sealed class BorderImageProperty : ShorthandProperty
    {
        private static readonly IValueConverter ImageConverter = WithAny(
            OptionalImageSourceConverter.Option().For(PropertyNames.BorderImageSource),
            WithOrder(
                BorderImageSliceProperty.TheConverter.Option().For(PropertyNames.BorderImageSlice),
                BorderImageWidthProperty.TheConverter.StartsWithDelimiter()
                    .Option()
                    .For(PropertyNames.BorderImageWidth),
                BorderImageOutsetProperty.TheConverter.StartsWithDelimiter()
                    .Option()
                    .For(PropertyNames.BorderImageOutset)),
            BorderImageRepeatProperty.TheConverter.Option().For(PropertyNames.BorderImageRepeat)).OrDefault();

        public BorderImageProperty()
            : base(PropertyNames.BorderImage)
        {
        }

        public override IValueConverter Converter => ImageConverter;
    }
}
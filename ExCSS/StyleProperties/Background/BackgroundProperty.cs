
namespace ExCSS
{
    using static Converters;

    public sealed class BackgroundProperty : ShorthandProperty
    {
        public BackgroundProperty()
            : base(PropertyNames.Background, PropertyFlags.Animatable)
        {
        }

        public override IValueConverter Converter => StyleConverter;

        private static readonly IValueConverter NormalLayerConverter = WithAny(
            OptionalImageSourceConverter.Option().For(PropertyNames.BackgroundImage),
            WithOrder(
                PointConverter.Option().For(PropertyNames.BackgroundPosition),
                BackgroundSizeConverter.StartsWithDelimiter().Option().For(PropertyNames.BackgroundSize)),
            BackgroundRepeatsConverter.Option().For(PropertyNames.BackgroundRepeat),
            BackgroundAttachmentConverter.Option().For(PropertyNames.BackgroundAttachment),
            BoxModelConverter.Option().For(PropertyNames.BackgroundOrigin),
            BoxModelConverter.Option().For(PropertyNames.BackgroundClip));

        private static readonly IValueConverter FinalLayerConverter = WithAny(
            OptionalImageSourceConverter.Option().For(PropertyNames.BackgroundImage),
            WithOrder(
                PointConverter.Option().For(PropertyNames.BackgroundPosition),
                BackgroundSizeConverter.StartsWithDelimiter().Option().For(PropertyNames.BackgroundSize)),
            BackgroundRepeatsConverter.Option().For(PropertyNames.BackgroundRepeat),
            BackgroundAttachmentConverter.Option().For(PropertyNames.BackgroundAttachment),
            BoxModelConverter.Option().For(PropertyNames.BackgroundOrigin),
            BoxModelConverter.Option().For(PropertyNames.BackgroundClip),
            CurrentColorConverter.Option().For(PropertyNames.BackgroundColor));

        private static readonly IValueConverter StyleConverter =
            NormalLayerConverter.RequiresEnd(FinalLayerConverter).OrDefault();
    }
}
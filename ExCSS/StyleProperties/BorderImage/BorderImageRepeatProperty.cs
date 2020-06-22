
namespace ExCSS
{
    public sealed class BorderImageRepeatProperty : Property
    {
        public static readonly IValueConverter TheConverter = Map.BorderRepeatModes.ToConverter().Many(1, 2);
        private static readonly IValueConverter StyleConverter = TheConverter.OrDefault(BorderRepeat.Stretch);

        public BorderImageRepeatProperty()
            : base(PropertyNames.BorderImageRepeat)
        {
        }

        public override IValueConverter Converter => StyleConverter;
    }
}

namespace ExCSS
{
    using static Converters;

    public sealed class BorderImageSliceProperty : Property
    {
        public static readonly IValueConverter TheConverter = WithAny(
           BorderSliceConverter.Option(new Length(100f, Length.Unit.Percent)),
           BorderSliceConverter.Option(),
           BorderSliceConverter.Option(),
           BorderSliceConverter.Option(),
           Assign(Keywords.Fill, true).Option(false));

        private static readonly IValueConverter StyleConverter = TheConverter.OrDefault(Length.Full);

        public BorderImageSliceProperty()
            : base(PropertyNames.BorderImageSlice)
        {
        }

        public override IValueConverter Converter => StyleConverter;


    }
}
namespace Collage.Engine
{
    using SunamoExceptions;
    using System;
    using System.Drawing;
    public class TileTransformer
    {
static Type type = typeof(TileTransformer);
        private readonly IRandomGenerator randomGenerator;
        
        public TileTransformer()
        {
            this.randomGenerator = new RandomGenerator();
        }
        public Image Transform(Image tile, TileTransformerSettings settings)
        {
            if (settings == null)
            {
                ThrowExceptions.IsNull(Exc.GetStackTrace(), type, Exc.CallingMethod(),"settings");
            }
            if (tile == null)
            {
                ThrowExceptions.IsNull(Exc.GetStackTrace(), type, Exc.CallingMethod(),"tile");
            }
            var tileScaled = tile.Scale(settings.ScalePercent);
                
            if (settings.RotateAndFlipRandomly)
            {
                tileScaled.RotateFlipRandom(this.randomGenerator);
            }
            if (Math.Abs(tileScaled.HorizontalResolution - settings.GraphicsDpiX) > 0.01 ||
                Math.Abs(tileScaled.VerticalResolution - settings.GraphicsDpiY) > 0.01)
            {
                tileScaled.SetResolution(settings.GraphicsDpiX, settings.GraphicsDpiY);
            }
            return tileScaled;
        }
    }
}

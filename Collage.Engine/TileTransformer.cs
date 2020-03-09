namespace Collage.Engine
{
    using System;
    using System.Drawing;

    internal class TileTransformer
    {
        private readonly IRandomGenerator randomGenerator;
        
        public TileTransformer()
        {
            this.randomGenerator = new RandomGenerator();
        }

        public Image Transform(Image tile, TileTransformerSettings settings)
        {
            if (settings == null)
            {
                ThrowExceptions.Custom(RuntimeHelper.GetStackTrace(), type, RH.CallingMethod(),ArgumentNullException("settings");
            }

            if (tile == null)
            {
                ThrowExceptions.Custom(RuntimeHelper.GetStackTrace(), type, RH.CallingMethod(),ArgumentNullException("tile");
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
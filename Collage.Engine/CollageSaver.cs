namespace Collage.Engine
{
    using SunamoExceptions;
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
    public class CollageSaver
    {
static Type type = typeof(CollageSaver);
        private readonly FileNameCreator fileNameCreator;
        public CollageSaver(DirectoryInfo outputDirectory)
        {
            if (outputDirectory == null)
            {
                ThrowExceptions.IsNull(Exc.GetStackTrace(), type, Exc.CallingMethod(),"outputDirectory");
            }
            
            this.fileNameCreator = new FileNameCreator(outputDirectory);
        }
        public FileInfo Save(Bitmap bitmap)
        {
            if (bitmap == null)
            {
                ThrowExceptions.IsNull(Exc.GetStackTrace(), type, Exc.CallingMethod(),"bitmap");
            }
            var fileName = this.fileNameCreator.CreateFileName();
            bitmap.Save(fileName, ImageFormat.Jpeg);
            bitmap.Dispose();
            return new FileInfo(fileName);
        }
    }
}
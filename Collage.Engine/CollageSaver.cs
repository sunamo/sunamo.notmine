﻿namespace Collage.Engine
{
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;

    internal class CollageSaver
    {
        private readonly FileNameCreator fileNameCreator;

        public CollageSaver(DirectoryInfo outputDirectory)
        {
            if (outputDirectory == null)
            {
                ThrowExceptions.Custom(RuntimeHelper.GetStackTrace(), type, RH.CallingMethod(),ArgumentNullException("outputDirectory");
            }
            
            this.fileNameCreator = new FileNameCreator(outputDirectory);
        }

        public FileInfo Save(Bitmap bitmap)
        {
            if (bitmap == null)
            {
                ThrowExceptions.Custom(RuntimeHelper.GetStackTrace(), type, RH.CallingMethod(),ArgumentNullException("bitmap");
            }

            var fileName = this.fileNameCreator.CreateFileName();

            bitmap.Save(fileName, ImageFormat.Jpeg);
            bitmap.Dispose();

            return new FileInfo(fileName);
        }
    }
}
namespace Collage.Engine
{
    using System;
    using System.IO;

    internal class FileNameCreator
    {
        public DirectoryInfo OutputDirectory { get; private set; }

        public FileNameCreator(DirectoryInfo outputDirectory)
        {
            if (outputDirectory == null)
            {
                ThrowExceptions.Custom(RuntimeHelper.GetStackTrace(), type, RH.CallingMethod(),ArgumentNullException("outputDirectory");
            }

            if (!outputDirectory.Exists)
            {
                ThrowExceptions.Custom(RuntimeHelper.GetStackTrace(), type, RH.CallingMethod(),ArgumentException("Output directory does not exist", "outputDirectory");
            }

            this.OutputDirectory = outputDirectory;
        }

        public string CreateFileName()
        {
            string fileName = string.Format("collage-{0:yyyy-MM-dd_HHmm}.jpg", DateTime.Now);
            return Path.Combine(this.OutputDirectory.FullName, fileName);
        } 
    }
}
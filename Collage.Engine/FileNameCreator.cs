namespace Collage.Engine
{
    using SunamoExceptions;
    using System;
    using System.IO;
    public class FileNameCreator
    {
static Type type = typeof(FileNameCreator);
        public DirectoryInfo OutputDirectory { get; private set; }
        public FileNameCreator(DirectoryInfo outputDirectory)
        {
            if (outputDirectory == null)
            {
                ThrowExceptions.IsNull(Exc.GetStackTrace(), type, Exc.CallingMethod(),"outputDirectory");
            }
            if (!outputDirectory.Exists)
            {
                ThrowExceptions.Custom(Exc.GetStackTrace(), type, Exc.CallingMethod(),"Output directory does not exist");
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

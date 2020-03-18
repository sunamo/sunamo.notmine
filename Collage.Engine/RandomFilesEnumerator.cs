namespace Collage.Engine
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    public class RandomFilesEnumerator : IFilesEnumerator
    {
static Type type = typeof(RandomFilesEnumerator);
        private readonly List<FileInfo> filesList;
        private readonly IRandomGenerator randomGenerator;
        public RandomFilesEnumerator(List<FileInfo> filesList)
        {
            if (filesList == null)
            {
                ThrowExceptions.IsNull(Exc.GetStackTrace(), type, Exc.CallingMethod(),"filesList");
            }
            
            this.filesList = filesList;
            this.randomGenerator = new RandomGenerator();
        }
        public string GetNextFileName()
        {
            return this.filesList[this.randomGenerator.Next(0, this.filesList.Count)].FullName;
        }
    }
}

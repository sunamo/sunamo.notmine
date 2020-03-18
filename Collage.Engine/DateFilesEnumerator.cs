namespace Collage.Engine
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    public class DateFilesEnumerator : IFilesEnumerator
    {
static Type type = typeof(DateFilesEnumerator);
        private readonly List<FileInfo> filesListOrderedByDate;
        public DateFilesEnumerator(IEnumerable<FileInfo> filesList)
        {
            if (filesList == null)
            {
                ThrowExceptions.IsNull(Exc.GetStackTrace(), type, Exc.CallingMethod(),"filesList");
            }
            this.filesListOrderedByDate = filesList.OrderBy(f => f.LastWriteTime).ToList();
        }
        private int currentFileIndex; 
        public string GetNextFileName()
        {
            string fileName = this.filesListOrderedByDate[this.currentFileIndex].FullName;
            this.currentFileIndex++;
            if (this.currentFileIndex >= this.filesListOrderedByDate.Count)
            {
                this.currentFileIndex = 0;
            }
            return fileName;
        }
    }
}

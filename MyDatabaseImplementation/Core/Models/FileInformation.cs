using System.IO;

namespace MyDatabaseImplementation.Core.Models
{
    public class FileInformation
    {
        public string Directory { get; }
        public string FileName { get; }
        public string FullPath { get; }

        public FileInformation(string directory, string fileName)
        {
            this.Directory = directory;
            this.FileName = fileName;
            this.FullPath = Path.Combine(this.Directory, this.FileName);
        }
    }
}

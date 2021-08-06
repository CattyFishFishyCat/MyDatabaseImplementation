using MyDatabaseImplementation.Core.Models;
using MyDatabaseImplementation.Utilities.FileHandlers.Database;
using System.IO;

namespace MyDatabaseImplementation.Utilities.FileHandlers.Generic
{
    public class FileCreator: IDatabaseFileCreator
    {
        public void CreateFile(FileInformation fileInformation)
        {
            Directory.CreateDirectory(fileInformation.Directory);
            File.Create(fileInformation.FullPath).Close();
        }
    }
}

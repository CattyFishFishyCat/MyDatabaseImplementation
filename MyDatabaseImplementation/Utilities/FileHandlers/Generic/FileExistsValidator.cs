using MyDatabaseImplementation.Core.Models;
using MyDatabaseImplementation.Utilities.FileHandlers.Database;
using System.IO;

namespace MyDatabaseImplementation.Utilities.FileHandlers.Generic
{
    public class FileExistsValidator: IDatabaseFileExistsValidator
    {
        public bool GetFileExists(FileInformation fileInformation)
        {
            return File.Exists(fileInformation.FullPath);
        }
    }
}

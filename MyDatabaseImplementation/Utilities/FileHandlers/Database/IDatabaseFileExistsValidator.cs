using MyDatabaseImplementation.Core.Models;

namespace MyDatabaseImplementation.Utilities.FileHandlers.Database
{
    public interface IDatabaseFileExistsValidator
    {
        bool GetFileExists(FileInformation fileInformation);
    }
}

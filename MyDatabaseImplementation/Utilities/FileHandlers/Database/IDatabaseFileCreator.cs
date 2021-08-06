using MyDatabaseImplementation.Core.Models;

namespace MyDatabaseImplementation.Utilities.FileHandlers.Database
{
    public interface IDatabaseFileCreator
    {
        void CreateFile(FileInformation fileInformation);
    }
}

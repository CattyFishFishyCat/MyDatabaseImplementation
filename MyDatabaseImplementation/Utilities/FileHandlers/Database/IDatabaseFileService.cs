using MyDatabaseImplementation.Core.Models;

namespace MyDatabaseImplementation.Utilities.FileHandlers.Database
{
    public interface IDatabaseFileService
    {
        FileInformation GetDbFileInformation(string dbFile);
        void CreateFileIfNeeded(FileInformation fileInformation, DatabaseInformationModel databaseInformation);
    }
}

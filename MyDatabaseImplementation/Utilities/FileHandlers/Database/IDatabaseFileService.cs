using MyDatabaseImplementation.Core.Models;

namespace MyDatabaseImplementation.Utilities.FileHandlers.Database
{
    public interface IDatabaseFileService
    {
        DatabaseFileInformation GetDbFileInformation(string dbFile);
        void CreateFileIfNeeded(DatabaseFileInformation fileInformation, DatabaseInformationModel databaseInformation);
    }
}

using MyDatabaseImplementation.Core.Models;

namespace MyDatabaseImplementation.Utilities.FileHandlers.Database
{
    public interface IDatabaseFileWriter
    {
        void Write(FileInformation fileInformation, DatabaseInformationModel databaseInformation);
    }
}

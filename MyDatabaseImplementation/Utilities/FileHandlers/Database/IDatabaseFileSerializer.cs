using MyDatabaseImplementation.Core.Models;

namespace MyDatabaseImplementation.Utilities.FileHandlers.Database
{
    public interface IDatabaseFileSerializer
    {
        string Serialize(DatabaseInformationModel databaseInformation);
    }
}

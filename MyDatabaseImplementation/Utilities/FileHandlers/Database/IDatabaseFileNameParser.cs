using MyDatabaseImplementation.Core.Models;

namespace MyDatabaseImplementation.Utilities.FileHandlers.Database
{
    public interface IDatabaseFileNameParser
    {
        FileInformation GetFileInformation(string dbFile);
    }
}

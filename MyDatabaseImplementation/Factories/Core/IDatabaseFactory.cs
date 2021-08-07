using MyDatabaseImplementation.Core;

namespace MyDatabaseImplementation.Factories.Core
{
    public interface IDatabaseFactory
    {
        IDatabase GetDatabase(string dbFile);
        IDatabase GetAndCreateDatabase(string dbFile);
    }
}

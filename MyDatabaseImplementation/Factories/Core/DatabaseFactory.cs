using MyDatabaseImplementation.Core;
using MyDatabaseImplementation.Utilities.FileHandlers.Database;
using MyDatabaseImplementation.Utilities.Logger;

namespace MyDatabaseImplementation.Factories.Core
{
    public class DatabaseFactory : IDatabaseFactory
    {
        private readonly IFatalLogger fatalLogger;
        private readonly IDatabaseFileService databaseFileService;

        public DatabaseFactory(IFatalLogger fatalLogger, IDatabaseFileService databaseFileService)
        {
            this.fatalLogger = fatalLogger;
            this.databaseFileService = databaseFileService;
        }

        public IDatabase GetDatabase(string dbFile)
        {
            return new Database(dbFile, this.fatalLogger, this.databaseFileService);
        }
    }
}

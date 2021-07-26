using MyDatabaseImplementation.Core;
using MyDatabaseImplementation.Factories.Utilities.FileHandlers.Database;
using MyDatabaseImplementation.Factories.Utilities.Logger;
using MyDatabaseImplementation.Utilities.FileHandlers.Database;
using MyDatabaseImplementation.Utilities.Logger;
using System;

namespace MyDatabaseImplementation.Factories.Core
{
    public class DatabaseFactory : IDatabaseFactory
    {
        private readonly ILoggerFactory loggerFactory;
        private readonly IDatabaseFileServiceFactory databaseFileServiceFactory;

        public DatabaseFactory(ILoggerFactory loggerFactory, IDatabaseFileServiceFactory databaseFileServiceFactory)
        {
            this.loggerFactory = loggerFactory;
            this.databaseFileServiceFactory = databaseFileServiceFactory;
        }

        public IDatabase GetDatabase(string dbFile)
        {
            return this.GetDatabase(dbFile, null, null);
        }

        public IDatabase GetDatabase(string dbFile, LogLevelEnum? logLevel, Action<string>? log)
        {
            ILogger logger = this.loggerFactory.GetLogger(logLevel, log);
            IDatabaseFileService databaseFileService = this.databaseFileServiceFactory.GetDatabaseFileService(logger);
            return new Database(dbFile, logger, databaseFileService);
        }
    }
}

using MyDatabaseImplementation.Factories.Utilities.Logger;
using MyDatabaseImplementation.Utilities.FileHandlers.Database;
using MyDatabaseImplementation.Utilities.Logger;
using System;

namespace MyDatabaseImplementation.Factories.Utilities.FileHandlers.Database
{
    public class DatabaseFileServiceFactory : IDatabaseFileServiceFactory
    {
        private readonly ILoggerFactory loggerFactory;

        public DatabaseFileServiceFactory(ILoggerFactory loggerFactory)
        {
            this.loggerFactory = loggerFactory;
        }

        public IDatabaseFileService GetDatabaseFileService(LogLevelEnum? logLevel, Action<string>? log = null)
        {
            return new DatabaseFileService(this.loggerFactory.GetLogger(logLevel, log));
        }

        public IDatabaseFileService GetDatabaseFileService(ILogger logger)
        {
            return new DatabaseFileService(logger);
        }
    }
}

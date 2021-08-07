using MyDatabaseImplementation.Core;
using MyDatabaseImplementation.Core.Models;
using MyDatabaseImplementation.Utilities.FileHandlers.Database;
using MyDatabaseImplementation.Utilities.Logger;
using System;

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

        public IDatabase GetAndCreateDatabase(string dbFile)
        {
            IDatabase database = this.GetDatabase(dbFile);
            database.CreateDatabaseIfNeeded();
            return database;
        }

        public IDatabase GetDatabase(string dbFile)
        {
            try
            {
                FileInformation dbFileInformation = this.databaseFileService.GetDbFileInformation(dbFile);
                return new Database(dbFileInformation, this.fatalLogger, this.databaseFileService);
            }
            catch (Exception)
            {
                this.fatalLogger.Log($"Unable to parse DB file name {dbFile}");
                throw;
            }
        }
    }
}

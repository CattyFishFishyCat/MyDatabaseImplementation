using MyDatabaseImplementation.Core.Models;
using MyDatabaseImplementation.Utilities.FileHandlers.Database;
using MyDatabaseImplementation.Utilities.Logger;
using System;
using System.Collections.Generic;

namespace MyDatabaseImplementation.Core
{
    public class Database : IDatabase
    {
        private readonly DatabaseFileInformation dbDirectory;
        private readonly IFatalLogger fatalLogger;
        private readonly IDatabaseFileService databaseFileService;

        public Database(string dbFile, IFatalLogger fatalLogger, IDatabaseFileService databaseFileService)
        {
            this.fatalLogger = fatalLogger;
            this.databaseFileService = databaseFileService;

            try
            {
                this.dbDirectory = this.databaseFileService.GetDbFileInformation(dbFile);
            }
            catch(Exception)
            {
                this.fatalLogger.Log($"Unable to parse DB file name {dbFile}");
                throw;
            }

            DatabaseInformationModel databaseInformation = new DatabaseInformationModel("0.1.0", new List<SchemaInformationModel>());

            try
            {
                this.databaseFileService.CreateFileIfNeeded(this.dbDirectory, databaseInformation);
            }
            catch(Exception)
            {
                this.fatalLogger.Log($"Unable to read or write file {this.dbDirectory.FullPath}");
                throw;
            }
        }

        public void Dispose()
        { }
    }
}

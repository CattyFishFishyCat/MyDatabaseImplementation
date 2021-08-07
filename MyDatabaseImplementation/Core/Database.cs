using MyDatabaseImplementation.Core.Models;
using MyDatabaseImplementation.Utilities.FileHandlers.Database;
using MyDatabaseImplementation.Utilities.Logger;
using System;
using System.Collections.Generic;

namespace MyDatabaseImplementation.Core
{
    public class Database : IDatabase
    {
        private readonly IFatalLogger fatalLogger;
        private readonly IDatabaseFileService databaseFileService;
        private readonly FileInformation dbFileInformation;

        public Database(FileInformation dbFileInformation, IFatalLogger fatalLogger, IDatabaseFileService databaseFileService)
        {
            this.fatalLogger = fatalLogger;
            this.databaseFileService = databaseFileService;
            this.dbFileInformation = dbFileInformation;
        }

        public void CreateDatabaseIfNeeded()
        {
            DatabaseInformationModel databaseInformation = new DatabaseInformationModel("0.1.0", new List<SchemaInformationModel>());

            try
            {
                this.databaseFileService.CreateFileIfNeeded(this.dbFileInformation, databaseInformation);
            }
            catch (Exception)
            {
                this.fatalLogger.Log($"Unable to read or write file {this.dbFileInformation.FullPath}");
                throw;
            }
        }

        public void Dispose()
        { }
    }
}

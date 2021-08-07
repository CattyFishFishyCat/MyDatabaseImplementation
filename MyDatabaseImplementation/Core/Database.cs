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
        private readonly string dbFile;
        private FileInformation? dbFileInformation;

        public Database(string dbFile, IFatalLogger fatalLogger, IDatabaseFileService databaseFileService)
        {
            this.fatalLogger = fatalLogger;
            this.databaseFileService = databaseFileService;
            this.dbFile = dbFile;
        }

        public void CreateDatabaseIfNeeded()
        {
            try
            {
                this.dbFileInformation = this.databaseFileService.GetDbFileInformation(this.dbFile);
            }
            catch (Exception)
            {
                this.fatalLogger.Log($"Unable to parse DB file name {this.dbFile}");
                throw;
            }

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

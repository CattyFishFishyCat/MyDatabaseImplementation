using MyDatabaseImplementation.Core.Exceptions;
using MyDatabaseImplementation.Core.Models;
using MyDatabaseImplementation.Utilities.Logger;
using Newtonsoft.Json;
using System.IO;
using System.Text;

namespace MyDatabaseImplementation.Utilities.FileHandlers.Database
{
    public class DatabaseFileService : IDatabaseFileService
    {
        private readonly IFatalLogger fatalLogger;
        private readonly IInformationLogger informationLogger;

        public DatabaseFileService(IFatalLogger fatalLogger, IInformationLogger informationLogger)
        {
            this.fatalLogger = fatalLogger;
            this.informationLogger = informationLogger;
        }

        public DatabaseFileInformation GetDbFileInformation(string dbFile)
        {
            try
            {
                string fullPath = dbFile;
                if (!Path.IsPathRooted(fullPath))
                {
                    fullPath = Path.Combine(Directory.GetCurrentDirectory(), dbFile);
                }

                return GetDbFileInformationFromFullPath(fullPath);
            }
            catch (DbDirectoryNotFoundException)
            {
                this.fatalLogger.Log($"Directory not found for {dbFile}.");
                throw;
            }
            catch (DbFileNameNotFoundException)
            {
                this.fatalLogger.Log($"File name not found for {dbFile}.");
                throw;
            }
        }

        private DatabaseFileInformation GetDbFileInformationFromFullPath(string dbFile)
        {
            string? directory = Path.GetDirectoryName(dbFile);
            if (string.IsNullOrEmpty(directory))
            {
                throw new DbDirectoryNotFoundException(dbFile);
            }

            string? file = Path.GetFileName(dbFile);
            if (string.IsNullOrEmpty(file))
            {
                throw new DbFileNameNotFoundException(dbFile);
            }

            return new DatabaseFileInformation(directory, file);
        }

        public void CreateFileIfNeeded(DatabaseFileInformation fileInformation, DatabaseInformationModel databaseInformation)
        {
            Directory.CreateDirectory(fileInformation.Directory);
            using(FileStream fileStream = new FileStream(fileInformation.FullPath, FileMode.OpenOrCreate, FileAccess.Write))
            {
                if (fileStream.Length == 0)
                {
                    this.informationLogger.Log($"{fileInformation.FullPath} does not exist. It will be created.");
                    string databaseInformationJson = JsonConvert.SerializeObject(databaseInformation);
                    byte[] databaseInformationBytes = Encoding.ASCII.GetBytes(databaseInformationJson);
                    fileStream.Write(databaseInformationBytes);
                }
            }
        }
    }
}

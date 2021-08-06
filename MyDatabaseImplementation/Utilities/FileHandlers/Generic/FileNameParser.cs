using MyDatabaseImplementation.Core.Exceptions;
using MyDatabaseImplementation.Core.Models;
using MyDatabaseImplementation.Utilities.FileHandlers.Database;
using MyDatabaseImplementation.Utilities.Logger;
using System.IO;

namespace MyDatabaseImplementation.Utilities.FileHandlers.Generic
{
    public class FileNameParser: IDatabaseFileNameParser
    {
        private readonly IErrorLogger errorLogger;

        public FileNameParser(IErrorLogger errorLogger)
        {
            this.errorLogger = errorLogger;
        }

        public FileInformation GetFileInformation(string dbFile)
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
                this.errorLogger.Log($"Directory not found for {dbFile}.");
                throw;
            }
            catch (DbFileNameNotFoundException)
            {
                this.errorLogger.Log($"File name not found for {dbFile}.");
                throw;
            }
        }

        private FileInformation GetDbFileInformationFromFullPath(string dbFile)
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

            return new FileInformation(directory, file);
        }
    }
}

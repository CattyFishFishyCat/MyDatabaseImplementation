using MyDatabaseImplementation.Core.Models;
using MyDatabaseImplementation.Utilities.Logger;

namespace MyDatabaseImplementation.Utilities.FileHandlers.Database
{
    public class DatabaseFileService : IDatabaseFileService
    {
        private readonly IInformationLogger informationLogger;
        private readonly IDatabaseFileNameParser databaseFileNameParser;
        private readonly IDatabaseFileCreator databaseFileCreator;
        private readonly IDatabaseFileWriter databaseFileWriter;
        private readonly IDatabaseFileExistsValidator databaseFileExistsValidator;

        public DatabaseFileService(IInformationLogger informationLogger, IDatabaseFileNameParser databaseFileNameParser, IDatabaseFileCreator databaseFileCreator, 
            IDatabaseFileWriter databaseFileWriter, IDatabaseFileExistsValidator databaseFileExistsValidator)
        {
            this.informationLogger = informationLogger;
            this.databaseFileNameParser = databaseFileNameParser;
            this.databaseFileCreator = databaseFileCreator;
            this.databaseFileWriter = databaseFileWriter;
            this.databaseFileExistsValidator = databaseFileExistsValidator;
        }

        public FileInformation GetDbFileInformation(string dbFile)
        {
            return this.databaseFileNameParser.GetFileInformation(dbFile);
        }

        public void CreateFileIfNeeded(FileInformation fileInformation, DatabaseInformationModel databaseInformation)
        {
            if(!this.databaseFileExistsValidator.GetFileExists(fileInformation))
            {
                this.informationLogger.Log($"{fileInformation.FullPath} does not exist. It will be created.");
                this.databaseFileCreator.CreateFile(fileInformation);
                this.databaseFileWriter.Write(fileInformation, databaseInformation);
            }
        }
    }
}

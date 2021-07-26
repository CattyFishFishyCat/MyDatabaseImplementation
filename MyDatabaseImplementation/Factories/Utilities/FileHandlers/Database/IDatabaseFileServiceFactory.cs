using MyDatabaseImplementation.Utilities.FileHandlers.Database;
using MyDatabaseImplementation.Utilities.Logger;
using System;

namespace MyDatabaseImplementation.Factories.Utilities.FileHandlers.Database
{
    public interface IDatabaseFileServiceFactory
    {
        IDatabaseFileService GetDatabaseFileService(LogLevelEnum? logLevel, Action<string>? log = null);
        IDatabaseFileService GetDatabaseFileService(ILogger logger);
    }
}

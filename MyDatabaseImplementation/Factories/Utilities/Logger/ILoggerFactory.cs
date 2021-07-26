using MyDatabaseImplementation.Utilities.Logger;
using System;

namespace MyDatabaseImplementation.Factories.Utilities.Logger
{
    public interface ILoggerFactory
    {
        ILogger GetLogger(LogLevelEnum? logLevel, Action<string>? log);
    }
}

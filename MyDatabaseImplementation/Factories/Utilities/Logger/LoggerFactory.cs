using MyDatabaseImplementation.Utilities.Logger;
using System;

namespace MyDatabaseImplementation.Factories.Utilities.Logger
{
    public class LoggerFactory : ILoggerFactory
    {
        public ILogger GetLogger(LogLevelEnum? logLevel, Action<string>? log)
        {
            return new MyDatabaseImplementation.Utilities.Logger.Logger(logLevel, log);
        }
    }
}

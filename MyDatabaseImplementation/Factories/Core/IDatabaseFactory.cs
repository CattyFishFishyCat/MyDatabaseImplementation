using MyDatabaseImplementation.Core;
using MyDatabaseImplementation.Utilities.Logger;
using System;

namespace MyDatabaseImplementation.Factories.Core
{
    public interface IDatabaseFactory
    {
        IDatabase GetDatabase(string dbFile);
        IDatabase GetDatabase(string dbFile, LogLevelEnum? logLevel, Action<string>? log);
    }
}

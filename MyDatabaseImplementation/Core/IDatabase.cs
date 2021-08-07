using System;

namespace MyDatabaseImplementation.Core
{
    public interface IDatabase : IDisposable
    {
        void CreateDatabaseIfNeeded();
    }
}

using System;

namespace MyDatabaseImplementation.Core.Exceptions
{
    [Serializable]
    public class DbDirectoryNotFoundException : Exception
    {
        public DbDirectoryNotFoundException() : base()
        { }

        public DbDirectoryNotFoundException(string dbFileName) :
            base($"Directory not found in file {dbFileName}.")
        { }

        public DbDirectoryNotFoundException(string message, Exception inner) : base(message, inner)
        { }

        protected DbDirectoryNotFoundException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}

using System;

namespace MyDatabaseImplementation.Core.Exceptions
{
    [Serializable]
    public class DbFileNameNotFoundException : Exception
    {
        public DbFileNameNotFoundException() : base()
        { }

        public DbFileNameNotFoundException(string dbFileName) :
            base($"File name not found in file {dbFileName}.")
        { }

        public DbFileNameNotFoundException(string message, Exception inner) : base(message, inner)
        { }

        protected DbFileNameNotFoundException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) 
        { }
    }
}

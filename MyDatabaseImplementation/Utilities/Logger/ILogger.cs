namespace MyDatabaseImplementation.Utilities.Logger
{
    public interface ILogger
    {
        void Fatal(string text);
        void Error(string text);
        void Debug(string text);
        void Information(string text);
        void Verbose(string text);
    }
}

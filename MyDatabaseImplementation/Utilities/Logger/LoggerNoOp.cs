namespace MyDatabaseImplementation.Utilities.Logger
{
    public class LoggerNoOp : IDebugLogger, IErrorLogger, IFatalLogger, IInformationLogger, IVerboseLogger
    {
        public void Log(string text)
        {
            //No action. Can be used when not wanting to log a particular log level.
        }
    }
}

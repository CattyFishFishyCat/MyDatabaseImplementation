using System;

namespace MyDatabaseImplementation.Utilities.Logger
{
    public class Logger : ILogger
    {
        private LogLevelEnum logLevel;
        private Action<string> log;

        public Logger(LogLevelEnum? logLevel, Action<string>? log)
        {
            this.logLevel = logLevel ?? LogLevelEnum.None;
            this.log = log ?? this.Log;
        }

        private void Log(string text)
        {
            Console.WriteLine(text);
        }

        public void Fatal(string text)
        {
            if (this.logLevel >= LogLevelEnum.Fatal)
            {
                this.log(text);
            }
        }

        public void Error(string text)
        {
            if (this.logLevel >= LogLevelEnum.Error)
            {
                this.log(text);
            }
        }

        public void Debug(string text)
        {
            if (this.logLevel >= LogLevelEnum.Debug)
            {
                this.log(text);
            }
        }

        public void Information(string text)
        {
            if (this.logLevel >= LogLevelEnum.Information)
            {
                this.log(text);
            }
        }

        public void Verbose(string text)
        {
            if (this.logLevel >= LogLevelEnum.Verbose)
            {
                this.log(text);
            }
        }
    }
}

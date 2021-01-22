using System;
using System.IO;

namespace ContactManager
{
    public enum LogLevel
    {
        Verbose = 1,
        Info = 2,
        Warning = 4,
        Error = 8,
    }

    public class LogMessageEventArgs : EventArgs
    {
        public readonly LogLevel Level;
        public readonly string Message;
        public readonly DateTime When;

        public LogMessageEventArgs(LogLevel level, string message)
        {
            this.When = DateTime.UtcNow;
            this.Level = level;
            this.Message = message;
        }

        public LogMessageEventArgs(LogLevel level, string format, params object[] arguments)
            : this(level, string.Format(format, arguments))
        { }
    }

    public static class Log
    {
        public static void Verbose(string message)
        {
            log(LogLevel.Verbose, message);
        }

        public static void Verbose(string format, params object[] args)
        {
            log(LogLevel.Verbose, string.Format(format, args));
        }

        public static void Info(string message)
        {
            log(LogLevel.Info, message);
        }

        public static void Info(string format, params object[] args)
        {
            log(LogLevel.Info, string.Format(format, args));
        }

        public static void Warning(string message)
        {
            log(LogLevel.Warning, message);
        }

        public static void Warning(string format, params object[] args)
        {
            log(LogLevel.Warning, string.Format(format, args));
        }

        public static void Error(string message)
        {
            log(LogLevel.Error, message);
        }

        public static void Error(string format, params object[] args)
        {
            log(LogLevel.Error, string.Format(format, args));
        }

        private static void log(LogLevel level, string message)
        {
            OnMessageLogged(new LogMessageEventArgs(level, message));
        }

        private static void OnMessageLogged(LogMessageEventArgs args)
        {
            MessageLogged?.Invoke(typeof(Log), args);
        }

        public static event EventHandler<LogMessageEventArgs> MessageLogged;
    }
}

using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;

namespace AtApi.Framework
{
    public static class LoggerExtensions
    {
        [DebuggerStepThrough]
        public static void Log(this ILogger logger, LogLevel logLevel, Func<string> logInfo)
        {
            if (logger.IsEnabled(logLevel))
            {
                logger.Log(logLevel, logInfo());
            }
        }
    }
}

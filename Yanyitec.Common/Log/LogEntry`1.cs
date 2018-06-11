using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Yanyitec.Log
{
    public class LogEntry<TState> : LogEntry
    {
        public LogEntry(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter):base(
            logLevel,
            eventId,
            exception,
            ()=>formatter==null?(DefaultFormatter(state,exception)):formatter(state,exception)
        ) {
        }

        static string DefaultFormatter(TState state, Exception exception) {
            StringBuilder sb = new StringBuilder();
            sb.Append("[STATE]\n");
            sb.Append(state).Append("\n");
            sb.Append("[/STATE]\n");
            while (exception != null) {
                sb.Append("[Exception]\n");
                sb.Append("@Type:").Append(exception.GetType().FullName).Append("\n");
                sb.Append("@Message").Append(exception.Message).Append("\n");
                sb.Append("@StackTrace").Append(exception.StackTrace).Append("\n");
                sb.Append("[/Exception]");
                exception = exception.InnerException;
            }
            return sb.ToString();
        }
        
    }
}

using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Yanyitec.Log
{
    public class LogEntry
    {
        public LogEntry(LogLevel logLevel, EventId eventId, Exception exception, Func<string> contentProvider) {
            this.LogLevel = logLevel;
            this.EventId = EventId;
            this.Exception = exception;
            this.ContentProvider = contentProvider;
            this.LogTime = DateTime.Now;
        }
        public DateTime LogTime { get; private set; }
        public LogLevel LogLevel { get;private set; }
        public EventId EventId { get; private set; }

        public Exception Exception { get; private set; }

        public Func<string> ContentProvider { get; private set; }
    }
}

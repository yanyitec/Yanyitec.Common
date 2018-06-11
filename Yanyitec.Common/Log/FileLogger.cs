
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
namespace Yanyitec.Log
{
    public class FileLogger : ILogger,IDisposable
    {
        List<LogEntry> _Entries;
        

        public FileLogger(string category) {
            this._Entries = new List<LogEntry>();
            this.Category = category;
        }
        public string Category { get; private set; }
        public IDisposable BeginScope<TState>(TState state)
        {
            return this;
        }

        public void Dispose()
        {
            
        }

        public void WriteEnitries(string basPath) {
            List<LogEntry> entries;
            lock (this) {
                entries = this._Entries;
                this._Entries = new List<LogEntry>();
            }
            DateTime logTime = DateTime.MinValue;
            StreamWriter writer = null;
            string path = null;
            try {
                foreach (var entry in entries)
                {
                    if (logTime == DateTime.MinValue || logTime.Year != entry.LogTime.Year || logTime.Month != entry.LogTime.Month || logTime.Day != entry.LogTime.Day) {
                        path = EnsureDir(entry.LogTime,this.Category, basPath);
                        if (writer != null) { writer.Close(); writer = null; }
                    }
                    if (logTime == DateTime.MinValue || logTime.Hour != entry.LogTime.Hour || logTime.Minute != entry.LogTime.Minute) {
                        if (writer != null) { writer.Close(); writer = null; }
                    }
                    if (writer == null) {
                        logTime = entry.LogTime;
                        var filename = path += "log"+logTime.ToString("hhmm") + ".log";
                        writer = File.CreateText(filename);
                    }
                    WriteEntry(entry,writer);
                    
                }
            } finally {
                if (writer != null) { writer.Close(); writer = null; }
            }
            
        }
        static void WriteEntry(LogEntry entry, StreamWriter writer) {
            writer.Write("#ENTRY====>");
            writer.Write(entry.LogTime.ToString());
            writer.Write("\n");
            writer.Write("@Level:");
            writer.Write(entry.LogLevel);
            writer.Write("\n");
            writer.Write("@EventId:");
            writer.Write(entry.EventId);
            writer.Write("\n");
            writer.Write(entry.ContentProvider());
            writer.Write("/======>\n\n");

        }
        static string EnsureDir(DateTime logTime, string category, string basPath) {
            var path = basPath;
            if (!string.IsNullOrEmpty(category))
            {
                path += category + "/";
            }
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);
            path += logTime.ToString("yyyy-MM-dd") + "/";
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);
            return path;
        }

        public static LogLevel Level = LogLevel.None;
        
        public bool IsEnabled(LogLevel logLevel)
        {
            var allowLevel = (int)Level;
            return (int)logLevel <= allowLevel;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            var entry = new LogEntry<TState>(logLevel,eventId,state,exception,formatter);
            lock (this) {
                this._Entries.Add(entry);
            }
        }
    }
}

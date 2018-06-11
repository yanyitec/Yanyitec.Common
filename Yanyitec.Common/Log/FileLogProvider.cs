using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Yanyitec.Log
{
    public class FileLogProvider : ILoggerProvider
    {
        ConcurrentDictionary<string, FileLogger> _Loggers;
        Task _Task;
        public FileLogProvider(string path=null) {
            this._Loggers = new ConcurrentDictionary<string, FileLogger>();
            this.Path = path ?? "./";
            if (!Directory.Exists(Path))
            {
                Directory.CreateDirectory(Path);
            }
            if (!this.Path.EndsWith('/') && this.Path.EndsWith('\\')) {
                this.Path += "/";
            }
            _Task = Task.Run(async ()=> {
                while (true)
                {
                    await Task.Delay(2000);
                    foreach (var pair in this._Loggers)
                    {
                        pair.Value.WriteEnitries(this.Path);
                    }
                }
            });
        }

        public string Path { get; private set; }
        
        
        public ILogger CreateLogger(string categoryName)
        {
            return this._Loggers.GetOrAdd(categoryName,(catename)=> new FileLogger(catename));
        }

        public void Dispose()
        {
            this._Loggers = null;
            _Task.Dispose();
            _Task = null;
        }

        public static FileLogProvider Default = new FileLogProvider();
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Crass.Crage
{
    public abstract class FileLogger : ILogger
    {
        public virtual ILogger Log(string log, LogLevel level = LogLevel.Info)
        {
            var targetDir = AppDomain.CurrentDomain.BaseDirectory;
            var targetPath = Path.Combine(targetDir, "crage.log");
            File.AppendAllText(targetPath, log);
            return this;
        }
    }
}

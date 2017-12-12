using System;
using System.Collections.Generic;
using System.Text;

namespace Crass.Crage
{
    public sealed class NullLogger : ILogger
    {
        private NullLogger() { }
        static NullLogger() => Instance = new NullLogger();
        public static NullLogger Instance { get; }

        public ILogger Log(string log, LogLevel level = LogLevel.Info)
        {
            return this;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Crass.Crage
{
    public class LogHelper
    {
        static LogHelper() => Default = NullLogger.Instance;
        public static ILogger Default { get; private set; }

        public static void Info(string log) => Default.Log(log);
        public static void InfoLine(string log = "") => Default.Log(log + Environment.NewLine);

        public static void Verbose(string log) => Default.Log(log, LogLevel.Verbose);
        public static void VerboseLine(string log = "") => Default.Log(log + Environment.NewLine, LogLevel.Verbose);

        public static ILogger SetLogger(CrageCmdArgs cmdArgs)
        {
            if (cmdArgs.Quiet) return Default = NullLogger.Instance;
            if (cmdArgs.Verbose) return Default = VerboseLogger.Instance;

            return Default = InfoLogger.Instance;
        }
    }
}

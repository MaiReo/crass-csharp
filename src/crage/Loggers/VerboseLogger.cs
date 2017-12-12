namespace Crass.Crage
{
    internal sealed class VerboseLogger : FileLogger,ILogger
    {
        private VerboseLogger() { }
        static VerboseLogger() => Instance = new VerboseLogger();
        public static ILogger Instance { get; private set; }

        public override ILogger Log(string log, LogLevel level = LogLevel.Info)
        {
            base.Log(log, level);
            if (level <= LogLevel.Verbose)
            {
                System.Console.Write(log);
            }
            return this;
        }
    }
}
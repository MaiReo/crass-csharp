namespace Crass.Crage
{
    internal sealed class InfoLogger : FileLogger, ILogger
    {
        private InfoLogger() { }
        static InfoLogger() => Instance = new InfoLogger();
        public static ILogger Instance { get; private set; }

        public override ILogger Log(string log, LogLevel level = LogLevel.Info)
        {
            base.Log(log, level);
            if (level <= LogLevel.Info)
            {
                System.Console.Write(log);
            }
            return this;
        }
    }
}
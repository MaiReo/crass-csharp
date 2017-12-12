namespace Crass.Crage
{
    public interface ILogger
    {
        ILogger Log(string log,LogLevel level = LogLevel.Info);
    }
}
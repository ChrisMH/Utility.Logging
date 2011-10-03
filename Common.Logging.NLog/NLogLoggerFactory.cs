namespace Common.Logging.NLog
{
  public class NLogLoggerFactory : LoggerFactoryBase
  {
    protected override ILogger CreateLogger(string name)
    {
      return new NLogLogger(name, global::NLog.LogManager.GetLogger(name));
    }
  }
}
namespace Utility.Logging.NLog.Autofac.Test
{
  public class LoggableBase
  {
    public LoggableBase(ILogger logger)
    {
      Logger = logger;
    }

    public ILogger Logger;

  }
}
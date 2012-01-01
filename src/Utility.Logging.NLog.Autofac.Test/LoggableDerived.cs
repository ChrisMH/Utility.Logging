
namespace Utility.Logging.NLog.Autofac.Test
{
  public class LoggableDerived : LoggableBase
  {
    public LoggableDerived(ILogger logger)
    : base(logger)
    {
      
    }
  }
}
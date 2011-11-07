using Ninject.Modules;

namespace Utility.Logging.NLog
{
  /// <summary>
  /// Ninject module to load factory and logger for NLog2.
  /// 
  /// </summary>
  public class NLogLoggerModule : NinjectModule
  {
    public override void Load()
    {
      Bind<ILoggerFactory>().To<NLogLoggerFactory>().InSingletonScope();
      Bind<ILogger>().ToMethod(
        context =>
          {
            if (context.Request.Target != null)
            {
              return ((ILoggerFactory) context.Kernel.GetService(typeof (ILoggerFactory))).GetLogger(context.Request.Target.Member.DeclaringType);
            }
            return ((ILoggerFactory) context.Kernel.GetService(typeof (ILoggerFactory))).GetLogger("UnknownTarget");
          });
    }
  }
}
using Autofac;
using Utility.Logging;
using Utility.Logging.NLog;

namespace $rootnamespace$
{
  public class NLogLoggerAutofacModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      builder.RegisterType<NLogLoggerFactory>()
        .As<ILoggerFactory>()
        .SingleInstance();
        
      builder.Register(c => c.Resolve<ILoggerFactory>().GetLogger("Root"))
        .As<ILogger>();
    }
  }
}

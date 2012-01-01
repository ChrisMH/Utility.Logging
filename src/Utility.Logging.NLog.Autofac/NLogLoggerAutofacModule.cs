using System.Linq;
using Autofac;
using Autofac.Core;

namespace Utility.Logging.NLog.Autofac
{
  public class NLogLoggerAutofacModule : Module
  {
    protected override void AttachToComponentRegistration(IComponentRegistry registry, IComponentRegistration registration)
    {
      registration.Preparing += OnComponentPreparing;
    }

    static void OnComponentPreparing(object sender, PreparingEventArgs e)
    {
      var t = e.Component.Activator.LimitType;
      e.Parameters = e.Parameters.Union(new[]
        {
            new ResolvedParameter((p, c) => p.ParameterType == typeof(ILogger), (p, c) => c.Resolve<ILoggerFactory>().GetLogger(t))
        });
    }

    protected override void Load(ContainerBuilder builder)
    {
      builder.RegisterType<NLogLoggerFactory>()
        .As<ILoggerFactory>()
        .SingleInstance();
    }
  }
}

using System.Linq;
using Autofac;
using Autofac.Core;
using Utility.Logging;
using Utility.Logging.NLog;

namespace $rootnamespace$
{
  public class NLogLoggerModule : Module
  {
    protected override void AttachToComponentRegistration(IComponentRegistry componentRegistry, IComponentRegistration registration)
    {
      registration.Preparing += OnPreparing;
    }

    private void OnPreparing(object sender, PreparingEventArgs e)
    {
      var typeName = e.Component.Activator.LimitType.Name;

      e.Parameters = e.Parameters.Union(
        new[]
          {
            new ResolvedParameter((p, i) => p.ParameterType == typeof (ILogger),
                                  (p, i) => i.Resolve<ILoggerFactory>().GetLogger(typeName))
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

using System.Linq;
using Autofac;
using Autofac.Core;

namespace Utility.Logging.NLog.Autofac
{
  public class NLogLoggerAutofacModule : Module
  {
    protected override void AttachToComponentRegistration(IComponentRegistry registry, IComponentRegistration registration)
    {
      registration.Preparing += (s, e) =>
      {
        e.Parameters = new [] { loggerParameter }.Concat(e.Parameters);
      };
    }

    protected override void Load(ContainerBuilder builder)
    {
      builder.RegisterType<NLogLoggerFactory>()
        .As<ILoggerFactory>()
        .SingleInstance();
    }

    private readonly Parameter loggerParameter =
      new ResolvedParameter((p, c) => p.ParameterType == typeof(ILogger),
                            (p, c) => c.Resolve<ILoggerFactory>().GetLogger(p.Member.DeclaringType));
  }
}

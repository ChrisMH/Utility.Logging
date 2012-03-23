using System;
using System.Linq;
using Microsoft.Practices.Unity;

namespace Utility.Logging.NLog.Unity
{
  public class NLogLoggerUnityExtension : UnityContainerExtension
  {
    protected override void Initialize()
    {
      this.Container.RegisterType<ILoggerFactory, NLogLoggerFactory>();
      this.Container.RegisterType<ILogger>(
        new InjectionFactory((container, type, name) 

    }
  }
}

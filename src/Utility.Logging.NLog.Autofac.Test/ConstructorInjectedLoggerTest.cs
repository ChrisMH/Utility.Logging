using Autofac;
using NUnit.Framework;
using Utility.Logging.NLog;
using Utility.Logging.NLog.Autofac;

namespace Utility.Logging.NLog.Autofac.Test
{
  public class ConstructorInjectedLoggerTest
  {
    [SetUp]
    public void SetUp()
    {
      var builder = new ContainerBuilder();
      builder.RegisterModule<NLogLoggerAutofacModule>();
      builder.RegisterType<LoggableBase>().AsSelf();
      builder.RegisterType<LoggableDerived>().AsSelf();
      container = builder.Build();
    }


    [Test]
    public void LoggerInjectedIntoBaseInstanceHasBaseInstanceName()
    {
      var result = container.Resolve<LoggableBase>();

      Assert.That(result.Logger.Name, Is.EqualTo("LoggableBase"));
    }

    [Test]
    public void LoggerInjectedIntoDerivedInstanceHasDerivedInstanceName()
    {
      var result = container.Resolve<LoggableDerived>();

      Assert.That(result.Logger.Name, Is.EqualTo("LoggableDerived"));
    }

    private IContainer container;
  }
}
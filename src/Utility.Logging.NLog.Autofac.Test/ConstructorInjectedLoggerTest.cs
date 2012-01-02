using System.Linq;
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
      builder.RegisterType<Server>().AsImplementedInterfaces();
      builder.RegisterType<ImplementedClient>().AsImplementedInterfaces();
      builder.RegisterType<DomainOne>().AsImplementedInterfaces();
      builder.RegisterType<DomainTwo>().AsImplementedInterfaces();
      builder.RegisterType<DomainLoader>().AsSelf();
      container = builder.Build();
    }


    [Test]
    public void LoggerInjectedIntoBaseInstanceHasBaseInstanceName()
    {
      var result = container.Resolve<LoggableBase>();

      Assert.That(result.Logger.Name, Is.EqualTo(typeof(LoggableBase).FullName));
    }

    [Test]
    public void LoggerInjectedIntoDerivedInstanceHasDerivedInstanceName()
    {
      var result = container.Resolve<LoggableDerived>();

      Assert.That(result.Logger.Name, Is.EqualTo(typeof(LoggableDerived).FullName));
    }

    [Test]
    public void LoggerInjectedIntoBaseInstanceWithInterfaceHasBaseInstanceName()
    {
      var result = container.Resolve<IServer>();

      Assert.That(result.Logger.Name, Is.EqualTo(typeof(Server).FullName));
    }

    [Test]
    public void LoggerInjectedIntoDerivedInstanceWithInterfaceHasDerivedInstanceName()
    {
      var result = container.Resolve<IClient>();

      Assert.That(result.Logger.Name, Is.EqualTo(typeof(ImplementedClient).FullName));
    }

    [Test]
    public void LoggerInjectedIntoInstancesMultiInjectedHaveDerivedInstanceNames()
    {
      var result = container.Resolve<DomainLoader>();

      Assert.That(result.Logger.Name, Is.EqualTo(typeof(DomainLoader).FullName));

      var domainOne = result.Domains.Single(d => d.GetType() == typeof (DomainOne));
      Assert.That(domainOne.Logger.Name, Is.EqualTo(typeof(DomainOne).FullName));

      var domainTwo = result.Domains.Single(d => d.GetType() == typeof(DomainTwo));
      Assert.That(domainTwo.Logger.Name, Is.EqualTo(typeof(DomainTwo).FullName));
    }
    
    private IContainer container;
  }
}
using System.Linq;
using Utility.Logging.NLog;
using Moq;
using NUnit.Framework;
using Ninject;
using Ninject.Activation;
using Ninject.Planning.Targets;

namespace Utility.Logging.Test
{
  public class NLogLoggerFactoryTest
  {
    [Test]
    public void CanRetrieveLoggerFactoryFromKernel()
    {
      var kernel = new StandardKernel(new NLogLoggerModule());

      var result = kernel.Get<ILoggerFactory>();

      Assert.NotNull(result);
    }

    [Test]
    public void CanCreateLoggerFromCurrentClass()
    {
      var loggerFactory = new NLogLoggerFactory();

      var logger = loggerFactory.GetCurrentClassLogger();

      Assert.NotNull(logger);
      Assert.AreEqual(GetType().FullName, logger.Name);
    }

    [Test]
    public void CanCreateLoggerFromType()
    {
      var loggerFactory = new NLogLoggerFactory();

      var logger = loggerFactory.GetLogger(GetType());

      Assert.NotNull(logger);
      Assert.AreEqual(GetType().FullName, logger.Name);
    }

    [Test]
    public void CanCreateLoggerFromName()
    {
      var loggerFactory = new NLogLoggerFactory();

      var logger = loggerFactory.GetLogger("logger name");

      Assert.NotNull(logger);
      Assert.AreEqual("logger name", logger.Name);
    }

  }
}
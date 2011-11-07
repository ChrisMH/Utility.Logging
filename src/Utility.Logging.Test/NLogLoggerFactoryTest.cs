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
    public void CanCreateLoggerFromCurrentClassWithLoggerFactory()
    {
      var loggerFactory = new NLogLoggerFactory();

      var logger = loggerFactory.GetCurrentClassLogger();

      Assert.NotNull(logger);
      Assert.AreEqual(GetType().FullName, logger.Name);
    }

    [Test]
    public void CanCreateLoggerFromTypeWithLoggerFactory()
    {
      var loggerFactory = new NLogLoggerFactory();

      var logger = loggerFactory.GetLogger(GetType());

      Assert.NotNull(logger);
      Assert.AreEqual(GetType().FullName, logger.Name);
    }

    [Test]
    public void CanCreateLoggerFromNameWithLoggerFactory()
    {
      var loggerFactory = new NLogLoggerFactory();

      var logger = loggerFactory.GetLogger("logger name");

      Assert.NotNull(logger);
      Assert.AreEqual("logger name", logger.Name);
    }


    [Test]
    public void CanCreateLoggerFromCurrentClassWithLogger()
    {
      var loggerFactory = new NLogLoggerFactory();
      var testLogger = loggerFactory.GetLogger("TestLogger");

      var logger = testLogger.GetCurrentClassLogger();

      Assert.NotNull(logger);
      Assert.AreEqual(GetType().FullName, logger.Name);
    }

    [Test]
    public void CanCreateLoggerFromTypeWithLogger()
    {
      var loggerFactory = new NLogLoggerFactory();
      var testLogger = loggerFactory.GetLogger("TestLogger");

      var logger = testLogger.GetLogger(GetType());

      Assert.NotNull(logger);
      Assert.AreEqual(GetType().FullName, logger.Name);
    }

    [Test]
    public void CanCreateLoggerFromNameWithLogge()
    {
      var loggerFactory = new NLogLoggerFactory();
      var testLogger = loggerFactory.GetLogger("TestLogger");

      var logger = testLogger.GetLogger("logger name");

      Assert.NotNull(logger);
      Assert.AreEqual("logger name", logger.Name);
    }

  }
}
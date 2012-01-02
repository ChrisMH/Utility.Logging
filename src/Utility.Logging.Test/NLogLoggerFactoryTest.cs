using NUnit.Framework;
using Utility.Logging.NLog;

namespace Utility.Logging.Test
{
  public class NLogLoggerFactoryTest
  {
    [Test]
    public void CanCreateLoggerFromCurrentClassWithLoggerFactory()
    {
      var loggerFactory = new NLogLoggerFactory();

      var logger = loggerFactory.GetCurrentInstanceLogger();

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
    public void CanCreateLoggerFromCurrentInstanceWithLogger()
    {
      var loggerFactory = new NLogLoggerFactory();
      var testLogger = loggerFactory.GetLogger("TestLogger");

      var logger = testLogger.GetCurrentInstanceLogger();

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
    public void CanCreateLoggerFromNameWithLogger()
    {
      var loggerFactory = new NLogLoggerFactory();
      var testLogger = loggerFactory.GetLogger("TestLogger");

      var logger = testLogger.GetLogger("logger name");

      Assert.NotNull(logger);
      Assert.AreEqual("logger name", logger.Name);
    }
  }
}
using System;
using Utility.Logging.NLog;
using NUnit.Framework;
using Ninject;

namespace Utility.Logging.Test
{
  public class NLogLoggerTest
  {
    [Test]
    public void CanInjectLogger()
    {
      var kernel = new StandardKernel(new NLogLoggerModule());
      kernel.Inject(this);

      Assert.NotNull(Logger);
      Assert.AreEqual(GetType().FullName, Logger.Name);
    }

    [Test]
    public void CanLogDebugMessage()
    {
      var kernel = new StandardKernel(new NLogLoggerModule());
      kernel.Inject(this);

      Logger.Debug("log: {0}", "can_log_debug_message");
    }

    [Test]
    public void CanLogDebugMessageWithException()
    {
      var kernel = new StandardKernel(new NLogLoggerModule());
      kernel.Inject(this);

      Logger.Debug("log: {0}", "can_log_debug_message_with_exception", new Exception("log exception"));
    }

    [Test]
    public void CanLogErrorMessage()
    {
      var kernel = new StandardKernel(new NLogLoggerModule());
      kernel.Inject(this);

      Logger.Error("log: {0}", "can_log_error_message");
    }

    [Test]
    public void CanLogErrorMessageWithException()
    {
      var kernel = new StandardKernel(new NLogLoggerModule());
      kernel.Inject(this);

      Logger.Error("log: {0}", "can_log_error_message_with_exception", new Exception("log exception"));
    }

    [Test]
    public void CanLogFatalMessage()
    {
      var kernel = new StandardKernel(new NLogLoggerModule());
      kernel.Inject(this);

      Logger.Fatal("log: {0}", "can_log_fatal_message");
    }

    [Test]
    public void CanLogFatalMessageWithException()
    {
      var kernel = new StandardKernel(new NLogLoggerModule());
      kernel.Inject(this);

      Logger.Fatal("log: {0}", "can_log_fatal_message_with_exception", new Exception("log exception"));
    }

    [Test]
    public void CanLogInfoMessage()
    {
      var kernel = new StandardKernel(new NLogLoggerModule());
      kernel.Inject(this);

      Logger.Info("log: {0}", "can_log_info_message");
    }

    [Test]
    public void CanLogInfoMessageWithException()
    {
      var kernel = new StandardKernel(new NLogLoggerModule());
      kernel.Inject(this);

      Logger.Info("log: {0}", "can_log_info_message_with_exception", new Exception("log exception"));
    }

    [Test]
    public void CanLogTraceMessage()
    {
      var kernel = new StandardKernel(new NLogLoggerModule());
      kernel.Inject(this);

      Logger.Trace("log: {0}", "can_log_trace_message");
    }

    [Test]
    public void CanLogTraceMessageWithException()
    {
      var kernel = new StandardKernel(new NLogLoggerModule());
      kernel.Inject(this);

      Logger.Trace("log: {0}", "can_log_trace_message_with_exception", new Exception("log exception"));
    }

    [Test]
    public void CanLogWarnMessage()
    {
      var kernel = new StandardKernel(new NLogLoggerModule());
      kernel.Inject(this);

      Logger.Warn("log: {0}", "can_log_warn_message");
    }

    [Test]
    public void CanLogWarnMessageWithException()
    {
      var kernel = new StandardKernel(new NLogLoggerModule());
      kernel.Inject(this);

      Logger.Warn("log: {0}", "can_log_warn_message_with_exception", new Exception("log exception"));
    }

    [Inject]
    public ILogger Logger { get; set; }
  }
}
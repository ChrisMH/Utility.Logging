using System;
using NUnit.Framework;
using Utility.Logging.NLog;

namespace Utility.Logging.Test
{
  public class NLogLoggerTest
  {
    [Test]
    public void CanLogDebugMessage()
    {
      var logger = new NLogLoggerFactory().GetCurrentInstanceLogger();

      logger.Debug("log: {0}", "can_log_debug_message");
    }

    [Test]
    public void CanLogDebugMessageWithException()
    {
      var logger = new NLogLoggerFactory().GetCurrentInstanceLogger();

      logger.Debug("log: {0}", "can_log_debug_message_with_exception", new Exception("log exception"));
    }

    [Test]
    public void CanLogErrorMessage()
    {
      var logger = new NLogLoggerFactory().GetCurrentInstanceLogger();

      logger.Error("log: {0}", "can_log_error_message");
    }

    [Test]
    public void CanLogErrorMessageWithException()
    {
      var logger = new NLogLoggerFactory().GetCurrentInstanceLogger();

      logger.Error("log: {0}", "can_log_error_message_with_exception", new Exception("log exception"));
    }

    [Test]
    public void CanLogFatalMessage()
    {
      var logger = new NLogLoggerFactory().GetCurrentInstanceLogger();

      logger.Fatal("log: {0}", "can_log_fatal_message");
    }

    [Test]
    public void CanLogFatalMessageWithException()
    {
      var logger = new NLogLoggerFactory().GetCurrentInstanceLogger();

      logger.Fatal("log: {0}", "can_log_fatal_message_with_exception", new Exception("log exception"));
    }

    [Test]
    public void CanLogInfoMessage()
    {
      var logger = new NLogLoggerFactory().GetCurrentInstanceLogger();

      logger.Info("log: {0}", "can_log_info_message");
    }

    [Test]
    public void CanLogInfoMessageWithException()
    {
      var logger = new NLogLoggerFactory().GetCurrentInstanceLogger();

      logger.Info("log: {0}", "can_log_info_message_with_exception", new Exception("log exception"));
    }

    [Test]
    public void CanLogTraceMessage()
    {
      var logger = new NLogLoggerFactory().GetCurrentInstanceLogger();

      logger.Trace("log: {0}", "can_log_trace_message");
    }

    [Test]
    public void CanLogTraceMessageWithException()
    {
      var logger = new NLogLoggerFactory().GetCurrentInstanceLogger();

      logger.Trace("log: {0}", "can_log_trace_message_with_exception", new Exception("log exception"));
    }

    [Test]
    public void CanLogWarnMessage()
    {
      var logger = new NLogLoggerFactory().GetCurrentInstanceLogger();

      logger.Warn("log: {0}", "can_log_warn_message");
    }

    [Test]
    public void CanLogWarnMessageWithException()
    {
      var logger = new NLogLoggerFactory().GetCurrentInstanceLogger();

      logger.Warn("log: {0}", "can_log_warn_message_with_exception", new Exception("log exception"));
    }
  }
}
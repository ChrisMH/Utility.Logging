using System;

namespace Utility.Logging
{
  public interface ILogger
  {
    void Debug(string message, params object[] parameters);
    void Debug(Exception exception, string message, params object[] parameters);

    void Error(string message, params object[] parameters);
    void Error(Exception exception, string message, params object[] parameters);

    void Fatal(string message, params object[] parameters);
    void Fatal(Exception exception, string message, params object[] parameters);

    void Info(string message, params object[] parameters);
    void Info(Exception exception, string message, params object[] parameters);

    void Trace(string message, params object[] parameters);
    void Trace(Exception exception, string message, params object[] parameters);

    void Warn(string message, params object[] parameters);
    void Warn(Exception exception, string message, params object[] parameters);

    bool IsDebugEnabled { get; }
    bool IsErrorEnabled { get; }
    bool IsFatalEnabled { get; }
    bool IsInfoEnabled { get; }
    bool IsTraceEnabled { get; }
    bool IsWarnEnabled { get; }

    string Name { get; }

    ILogger GetCurrentInstanceLogger();
    ILogger GetLogger(Type type);
    ILogger GetLogger(string name);
  }
}
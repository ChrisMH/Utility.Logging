using System;

namespace Common.Logging
{
  public abstract class LoggerBase : ILogger, IDisposable
  {
    protected LoggerBase(string name)
    {
      if (name == null) throw new ArgumentException("name not supplied", "name");

      Name = name;
    }

    public void Dispose()
    {
      GC.SuppressFinalize(this);
    }

    public abstract void Debug(string message, params object[] parameters);
    public abstract void Debug(Exception exception, string message, params object[] parameters);

    public abstract void Error(string message, params object[] parameters);
    public abstract void Error(Exception exception, string message, params object[] parameters);

    public abstract void Fatal(string message, params object[] parameters);
    public abstract void Fatal(Exception exception, string message, params object[] parameters);

    public abstract void Info(string message, params object[] parameters);
    public abstract void Info(Exception exception, string message, params object[] parameters);

    public abstract void Trace(string message, params object[] parameters);
    public abstract void Trace(Exception exception, string message, params object[] parameters);

    public abstract void Warn(string message, params object[] parameters);
    public abstract void Warn(Exception exception, string message, params object[] parameters);

    public abstract bool IsDebugEnabled { get; }
    public abstract bool IsErrorEnabled { get; }
    public abstract bool IsFatalEnabled { get; }
    public abstract bool IsInfoEnabled { get; }
    public abstract bool IsTraceEnabled { get; }
    public abstract bool IsWarnEnabled { get; }

    public string Name { get; private set; }
  }
}
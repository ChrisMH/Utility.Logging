using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Utility.Logging
{
  public abstract class LoggerBase : ILogger, IDisposable
  {
    protected LoggerBase(string name, ILoggerFactory factory)
    {
      if (name == null) throw new ArgumentException("name not supplied", "name");

      Name = name;
      this.factory = factory;
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

    // This method relies on the stack to retrieve the current class, so preventing inlining is required.
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ILogger GetCurrentInstanceLogger()
    {
      return factory.GetCurrentInstanceLogger(2);
    }

    public ILogger GetLogger(Type type)
    {
      return factory.GetLogger(type);
    }

    public ILogger GetLogger(string name)
    {
      return factory.GetLogger(name);
    }


    private ILoggerFactory factory;
  }
}
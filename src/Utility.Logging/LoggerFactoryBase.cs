using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Utility.Logging
{
  public abstract class LoggerFactoryBase : ILoggerFactory
  {
    /// <summary>
    /// Overridden in logging specific factory to create a real logger
    /// </summary>
    /// <param name="name">Name of the logger to create</param>
    /// <returns>The logger</returns>
    protected abstract ILogger CreateLogger(string name);

    // This method relies on the stack to retrieve the current class, so preventing inlining is required.
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ILogger GetCurrentInstanceLogger(int skipFrames = 1)
    {
      // Go up one call on the frame and get the type that declares that method.
      var stackFrame = new StackFrame(skipFrames);
      return GetLogger(stackFrame.GetMethod().ReflectedType);
    }

    public ILogger GetLogger(Type type)
    {
      return GetLogger(type.FullName);
    }

    public ILogger GetLogger(string name)
    {
      if (!_loggerCache.ContainsKey(name))
      {
        _loggerCache[name] = CreateLogger(name);
      }
      return _loggerCache[name];
    }

    private readonly Dictionary<string, ILogger> _loggerCache = new Dictionary<string, ILogger>();
  }
}
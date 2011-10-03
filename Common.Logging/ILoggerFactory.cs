using System;

namespace Common.Logging
{
  public interface ILoggerFactory
  {
    /// <summary>
    /// Get a logger for the class that called this method
    /// </summary>
    /// <returns>The logger</returns>
    ILogger GetCurrentClassLogger();

    /// <summary>
    /// Gets a logger named for a specific type
    /// </summary>
    /// <param name="type">The type</param>
    /// <returns>The logger</returns>
    ILogger GetLogger(Type type);

    /// <summary>
    /// Gets a named logger
    /// </summary>
    /// <param name="name">The logger name</param>
    /// <returns>The logger</returns>
    ILogger GetLogger(string name);
  }
}
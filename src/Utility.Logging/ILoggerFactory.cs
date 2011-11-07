using System;

namespace Utility.Logging
{
  public interface ILoggerFactory
  {
    /// <summary>
    /// Get a logger for the class that called this method
    /// </summary>
    /// <param name="skipFrames">Number of stack frames to skip to get to the initiating call</param>
    /// <returns>The logger</returns>
    ILogger GetCurrentClassLogger(int skipFrames = 1);

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
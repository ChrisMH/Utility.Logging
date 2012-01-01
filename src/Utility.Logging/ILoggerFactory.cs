using System;

namespace Utility.Logging
{
  public interface ILoggerFactory
  {
    /// <summary>
    /// Get a logger for the class instance that called this method
    /// Note that this will return will return the class name of the class that
    /// declares the calling method, not necessarily the most-derived class
    /// of a class hierarchy.
    /// </summary>
    /// <param name="skipFrames">Number of stack frames to skip to get to the initiating call</param>
    /// <returns>The logger</returns>
    ILogger GetCurrentInstanceLogger(int skipFrames = 1);

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
using System.Collections.Generic;
using System.Linq;

namespace Utility.Logging.NLog.Autofac.Test
{
  public class LoggableBase
  {
    public LoggableBase(ILogger logger)
    {
      Logger = logger;
    }

    public ILogger Logger;

  }

  public class LoggableDerived : LoggableBase
  {
    public LoggableDerived(ILogger logger)
      : base(logger)
    {

    }
  }

  public interface IServer
  {
    void Start();
    ILogger Logger { get; }
  }

  public class Server : IServer
  {
    public Server(ILogger logger)
    {
      Logger = logger;
    }

    public void Start()
    {
      
    }

    public ILogger Logger { get; private set; }
  }


  public interface IClient
  {
    void Start();
    ILogger Logger { get; }
  }

  public abstract class Client : IClient
  {
    protected Client(ILogger logger)
    {
      Logger = logger;
    }

    public void Start()
    {

    }

    public ILogger Logger { get; private set; }
  }

  public class ImplementedClient : Client
  {
    public ImplementedClient(ILogger logger) 
    : base(logger)
    {
    }
  }


  public interface IDomain
  {
    ILogger Logger { get; }
  }

  public abstract class DomainBase : IDomain
  {
    protected DomainBase(ILogger logger)
    {
      Logger = logger;
    }

    public ILogger Logger { get; private set; }
  }

  public class DomainOne : DomainBase
  {
    public DomainOne(ILogger logger) : base(logger)
    {
    }
  }

  public class DomainTwo : DomainBase
  {
    public DomainTwo(ILogger logger)
      : base(logger)
    {
    }
  }

  public class DomainLoader
  {
    public DomainLoader(IEnumerable<IDomain> domains, ILogger logger)
    {
      Domains = domains.ToList();
      Logger = logger;
    }

    public List<IDomain> Domains;
    public ILogger Logger;
  }
}
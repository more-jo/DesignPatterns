// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var t = Singleton.Instance;


public sealed class Singleton
{
  // reading this will initialize the instance
  public static readonly Lazy<Singleton> _lazy = new Lazy<Singleton> (() => new Singleton());

  public static Singleton Instance
  {
    get
    {
      Logger.Log("Instance called."); // lazy instanciation
      return _lazy.Value; // guaranteed to never be null.
    }
  }

  public Singleton()
  {
    // cannot be created except within this class.
    Logger.Log("Constructor invoked");
  }
}

public class Logger
{
  public static void Log(string message)
  {
    Console.WriteLine(message);
  }
}
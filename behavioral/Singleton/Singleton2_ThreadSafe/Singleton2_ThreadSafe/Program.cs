// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


// bad code
// Source: https://csharpindepth.com/articles/singleton
public sealed class Singleon
{
  private static Singleon _instance = null;
  private static readonly object padlock = new object(); // never use a public, shared value that can be used by another istance.
  // lock istances should be paired with their lock statements.

  //private static Singleon? _instance; 
  // 1. the only static field that contains the intance.
  // 2. make it nullable

  public static Singleon Instance
  {
    get
    {
      Logger.Log("Instance called."); // lazy instanciation

      lock (padlock) // this lock is used on *every* reference to Singleton
      {
        if(_instance == null)
        {
          _instance = new Singleon();
        }
        return _instance;
      }
      
    }
  }

  public Singleon()
  {
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
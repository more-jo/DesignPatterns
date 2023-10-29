// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


// Source: https://csharpindepth.com/articles/singleton
public sealed class Singleton
{
  private static Singleton _instance = new Singleton();

  // reading this will initialize the _instance
  public static readonly string GREETING = "Hi!";
  // as soon something other static is read, then this instance is also initialized.

  // Tell c# compiler not to mark type as beforefieldinit
  // (https://csharpindepth.com/articles/BeforeFieldInit)
  static Singleton()
  {
  } //ensures that the class is marked as not beforefieldinit



  public static Singleton Instance
  {
    get
    {
      Logger.Log("Instance called."); // lazy instanciation
      
      return Nested._instance;
    }
  }

  private class Nested
  {
    // Tell c# compiler not to mark tyupe as beforefieldinit (https://csharpindepth.com/articles/BeforeFieldInit)
    static Nested()
    {
    }
    internal static readonly Singleton _instance = new Singleton(); // this way it is called not too soon.    
  }

  public Singleton()
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
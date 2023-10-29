using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton1_Naive
{
  internal class Program
  {
    static void Main(string[] args)
    {
      Logger.Log("test");
    }
  }

  public sealed class Singleon
  {
    // starting with c# 8 one can use nullable type to clean up:

    //#nullable enable

    private static Singleon _instance; // the only static field that contains the intance.

    //private static Singleon? _instance; 
    // 1. the only static field that contains the intance.
    // 2. make it nullable

    public static Singleon Instance
    {
      get
      {
        Logger.Log("Instance called."); // lazy instanciation
        
        //return ??= new Singleton(); // nullable reference starting with .NET 8. It assigns only if the variable is null.
        
        if (_instance == null) // Naive implementation is naive, because the block can be entered several times during parallel processing.
        {
          _instance = new Singleon();
        }

        return _instance;
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

}

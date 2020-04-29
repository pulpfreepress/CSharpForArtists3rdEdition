using System;

public class EnvironmentClassDemo {

  public static void Main(){
    string[] args = Environment.GetCommandLineArgs();
	Console.WriteLine("First Argument: " + args[0]);
	for(int i = 1; i<args.Length; i++){
	  Console.WriteLine(args[i]);
	}
  }// end Main()
}// end EnvironmentClassDemo
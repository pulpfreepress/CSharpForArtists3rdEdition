using System;

public class SubStrings {
  public static void Main(){
    string s1 = "I come to you, my true love, with open arms!";
	
	Console.WriteLine("     Substring(7): " + s1.Substring(7));
	Console.WriteLine("Substring(15, 12): " + s1.Substring(15,12));
	Console.WriteLine(" Substring(0, 13): " + s1.Substring(0,13));
  } // end Main()
} // end SubStrings class definition
using System;

public class FindFirstOrLast {
  public static void Main(){
    string s1 = "I like to write on Saturdays and nap on Sundays!";
	int startIndex = s1.IndexOf("write");
	int endIndex = s1.LastIndexOf("write");
	Console.WriteLine("s1: " + s1);
	Console.WriteLine("First occurrence of \"write\" starts at position: " + startIndex);
	Console.WriteLine(" Last occurrence of \"write\" starts at position: " + endIndex);
	startIndex = s1.IndexOf("on");
	endIndex = s1.LastIndexOf("on");
	Console.WriteLine("First occurrence of \"on\" starts at position: " + startIndex);
	Console.WriteLine(" Last occurrence of \"on\" starts at position: " + endIndex);
  } // end Main()
} // end FindFirstOrLast class definition
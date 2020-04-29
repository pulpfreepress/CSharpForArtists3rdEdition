using System;

public class SplitStrings {
  public static void Main(){
	string s1 = "Jan,Feb,Mar,Apr,May,Jun,Jul,Aug,Sept,Oct,Nov,Dec";
	Console.WriteLine("Original s1: " + s1);
	
	Console.WriteLine("s1 split and converted to upper case:");
	string[] months = s1.Split(',');
	foreach(string s in months){
	  Console.Write(s.ToUpper() + "\t");	
	}
  } // end Main()
} // end SplitStrings class definition
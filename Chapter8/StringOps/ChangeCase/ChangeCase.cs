using System;
using System.Threading;
using System.Globalization;

public class ChangeCase {
	
  public static void Main(){
	 string s1 = "This is an ordinary string literal. Not much to look at here.";
	
	 // ToUpper() and ToLower() return new strings. 
	 // Original string is unaffected
	 Console.WriteLine("                      s1: " + s1);
	 Console.WriteLine("            s1.ToUpper(): " + s1.ToUpper());
	 Console.WriteLine("            s1.ToLower(): " + s1.ToLower());
	 Console.WriteLine("                      s1: " + s1);
	 Console.WriteLine("****** Make s1 Lower-Case ***************************************");
	 // Make s1 a lower-case string
	 s1 = s1.ToLower();
	 Console.WriteLine("                      s1: " + s1);
	 
	 CultureInfo cultureInfo   = Thread.CurrentThread.CurrentCulture;
     TextInfo textInfo = cultureInfo.TextInfo;
	 
	 Console.WriteLine("textInfo.ToTitleCase(s1): " + textInfo.ToTitleCase(s1));
	 Console.WriteLine("    textInfo.ToUpper(s1): " + textInfo.ToUpper(s1));
	 Console.WriteLine("    textInfo.ToLower(s1): " + textInfo.ToLower(s1));
	 Console.WriteLine("                      s1: " + s1);
	 
	} // end Main()
} // end ChangeCase class definition
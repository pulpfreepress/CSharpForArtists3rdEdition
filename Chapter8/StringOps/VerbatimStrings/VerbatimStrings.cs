using System;

public class VerbatimStrings {
  public static void Main(){
	string s1 = "String literal with escape sequences:  backslash \\, \'single quotes\'," +
                " and \"double quotes\"";
	string s2 = @"Verbatim string with: backslash \, 'single quotes', and ""double quotes""";
	Console.WriteLine(s1);
	Console.WriteLine(s2);
  }// end Main()
}// end VerbatimStrings class definition
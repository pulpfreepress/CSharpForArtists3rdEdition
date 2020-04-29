using System;

public class ForeachDemo {
  public static void Main(){
	string[] string_array = { "Oh", "if", "you", "loved", "C#",
	                        "like", "I", "loved", "C#!" };
							
	foreach(string s in string_array){
	  Console.Write(s + " ");
	}
  }
} 
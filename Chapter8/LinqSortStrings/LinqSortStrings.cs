using System;
using System.Linq;

public class LinqSortStrings {
  public static void Main(string[] args){
    if(args.Length > 0){ 
	  // Sort strings by Length in ascending order
	  var query = args.OrderBy(s => s.Length); 
	
	  foreach(string s in query){
		Console.Write(s + " | ");
	  }
	  
	  Console.WriteLine();
	  
	  // Sort strings alphabetically 
	  query = args.OrderBy(s => s);
	  
	  foreach(string s in query){
		Console.Write(s + " | ");
	  }
	  
	  Console.WriteLine();
	  
	  // The sort the sorted strings by Length
	  foreach(string s in query.OrderBy(s => s.Length)){
		Console.Write(s + " | ");
	  }
	}
  }
}
using System;

public class ValueTupleDemo {
	
	
	public (string, string) GetUnnamedTuple(){
		return ("Billy", "Hardison");
	}
	
	public (string FirstName, string LastName) GetNamedTuple(){
		return ("Steven", "Hester");
	}
	
	public static void Main(){
		ValueTupleDemo utd = new ValueTupleDemo();
		var unnamed = utd.GetUnnamedTuple();
		Console.WriteLine(unnamed.Item1 + " " + unnamed.Item2);
		var named = utd.GetNamedTuple();
		Console.WriteLine(named.FirstName + " " + named.LastName);
		Console.WriteLine(named.Item1 + " " + named.Item2);
	}
	
} // end class
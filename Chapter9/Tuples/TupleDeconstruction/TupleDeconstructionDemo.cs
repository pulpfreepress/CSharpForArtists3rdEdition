using System;

public class TupleDeconstructionDemo {
	
	public (string, string) GetUnnamedTuple(){
		return ("Laura", "Richter");
	}
	
	public (string FirstName, string LastName) GetNamedTuple(){
		return ("Diana", "Bath");
	}
	
	public static void Main(){
		TupleDeconstructionDemo tdd = new TupleDeconstructionDemo();
		var unnamed = tdd.GetUnnamedTuple();
		Console.WriteLine(unnamed.Item1 + " " + unnamed.Item2);
		var named = tdd.GetNamedTuple();
		Console.WriteLine(named.FirstName + " " + named.LastName);
		Console.WriteLine(named.Item1 + " " + named.Item2);
		// Tuple Deconstruction
		(string FirstName, string LastName) = tdd.GetUnnamedTuple();
		Console.WriteLine(FirstName + " " + LastName);
		// Tuple Discards
		(string FirstName_1, _) = tdd.GetUnnamedTuple();
		Console.WriteLine(FirstName_1);
		// Tuples are types
		(string FirstName_2, string LastName_2)p1 = tdd.GetNamedTuple();
		Console.WriteLine(p1.FirstName_2 + " " + p1.LastName_2);
		//Console.WriteLine(FirstName_2 + " " + LastName_2);
	}
	
} // end class
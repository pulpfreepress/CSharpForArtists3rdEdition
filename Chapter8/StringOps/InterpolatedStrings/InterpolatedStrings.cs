using System;

public class InterpolatedStrings {
  public static void Main(){
    string firstName = "Coralie";
	string lastName  = "Powell";
	
	//String Concatenation
	Console.WriteLine(firstName + " " + lastName + " is an amazing girl!");
	//Composite String
	Console.WriteLine("{0} {1} is an amazing girl!", firstName, lastName);
	//Interpolated String
	Console.WriteLine($"{firstName} {lastName} is an amazing girl!");
	
  }// end Main()
}// end InterpolatedStrings class definition
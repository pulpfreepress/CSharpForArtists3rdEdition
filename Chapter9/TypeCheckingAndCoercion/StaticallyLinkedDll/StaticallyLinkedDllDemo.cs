using System;

public class StaticallyLinkedDllDemo {

	public static void Main(){
		
		object obj1 = new Person();
		object obj2 = new Student();
		
		/**** Getting object's type with GetType() ****/
		Console.WriteLine("------- Getting object's type with GetType() -------");
		Console.WriteLine("obj1 is type: " + obj1.GetType());
		Console.WriteLine("obj2 is type: " + obj2.GetType());
		
		/**** Type checking with typeof operator ****/
		Console.WriteLine("------- Type checking with typeof operator -------");
		Console.WriteLine("obj1 is a Person: " + (obj1.GetType() == typeof(Person)));
		Console.WriteLine("obj2 is a Student: " + (obj2.GetType() == typeof(Student)));
		Console.WriteLine("obj2 is a Person: " + (obj2.GetType() == typeof(Person)));
		
		/**** Type checking with is operator ****/
		Console.WriteLine("-------- Type checking with is operator ---------");
		Console.WriteLine("obj1 is a Person: " + (obj1 is Person));
		Console.WriteLine("obj2 is a Student: " + (obj2 is Student));
		Console.WriteLine("obj2 is a Person: " + (obj2 is Person)); // Yes, because Student IS A Person
		
		/**** Type coercion via casting ****/
		Console.WriteLine("-------- Type coercion with via casting ---------");
		Console.WriteLine("obj1 First Name: " + ((Person)obj1).FirstName);
		Console.WriteLine("obj2 First Name: " + ((Student)obj2).FirstName);
		Console.WriteLine("obj2 First Name: " + ((Person)obj2).FirstName);
		
		try {
			Console.WriteLine("obj1 First Name: " + ((Student)obj1).FirstName); // Throws InvalidCast exception
		}catch(InvalidCastException e){
			Console.WriteLine("Problem Casting Person object to Student type.");
			Console.WriteLine(e);
		}
		
		Console.WriteLine("-------- Type coercion with as operator ---------");
		Person p1 = obj2 as Person;  // This works because a Student *IS A* Person
		if(p1 != null){
			Console.WriteLine("p1 FirstName = " + p1.FirstName);
		} else {
			Console.WriteLine("Conversion failed.");
		}
		
		Student s1 = obj1 as Student; // This fails but does not throw and exception
		if(s1 != null){
			Console.WriteLine("s1 FirstName = " + s1.FirstName);
		} else {
			Console.WriteLine("Conversion failed.");
		}
	} // end Main()
} // end class
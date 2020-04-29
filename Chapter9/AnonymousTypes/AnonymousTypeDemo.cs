using System;
using System.Linq;

public class AnonymousTypeDemo {

	public static void Main(){
		
		Person[] person_array = new Person[5];
		person_array[0] = new Person { FirstName = "Juliet", MiddleName = "Samantha", LastName = "Straus" };
		person_array[1] = new Person { FirstName = "Rick", MiddleName = "Warren", LastName = "Miller" };
		person_array[2] = new Person { FirstName = "Sierra", MiddleName = "Autumn", LastName = "Papay" };
		person_array[3] = new Person { FirstName = "Alex", MiddleName = "Theodore", LastName = "Remily" };
		person_array[4] = new Person { FirstName = "Tri", MiddleName = "Houng", LastName = "Nguyen" };
	
		var person_query = 
			from p in person_array.OrderBy(p => p.LastName)
			select new {p.FirstName, p.LastName};
			
		foreach(var p in person_query){
			Console.WriteLine("FirstName = {0}, LastName = {1}", p.FirstName, p.LastName);
		}
		
	} // end Main()
} // end class 
using System;

public class MainApp {
	public static void Main(){
	   Person p = new Person("Denise", "Marie", "Weber");
       Console.WriteLine("Person p's name is: " + p.FirstName + " " 
						+ p.MiddleName + " " + p.LastName);	  
       Person p2 = new Person();
        Console.WriteLine("Person p2's name is: " + p2.FirstName + " " 
						+ p2.MiddleName + " " + p2.LastName);	   
		p2.Relatives.Add(p);
		
		foreach(Person relation in p2.Relatives){
			 Console.WriteLine(relation.FirstName + " " + relation.MiddleName + " " 
			 + relation.LastName + " is a relative of " + p2.FirstName + " " 
			 + p2.LastName);	
		}
		
		Student s1 = new Student("Sierra", "Autumn", "Papay");
		Console.WriteLine("Student Name: " + s1.FirstName + " " + s1.MiddleName + " " + s1.LastName);
		s1.FirstName = "Jessica";
		Console.WriteLine("Student Name: " + s1.FirstName + " " + s1.MiddleName + " " + s1.LastName);
		// s1.MiddleName = "Jupiter"; --> NO PUBLIC ACCESS
		// s1.LastName = "Jones";  --> NO PUBLIC ACCESS
		s1.ChangeFirstAndMiddleNames("Jumpin'", "Jupiter");
		Console.WriteLine("Student Name: " + s1.FirstName + " " + s1.MiddleName + " " + s1.LastName);
	}
}
using System;

public class MainApp {
	public static void Main(){
		
		Person p1 = new Person {
							FirstName = "Juliet",
							MiddleName = "Samantha",
							LastName = "Straus"
					};	
		
		
		Student s1 = new Student { 
							StudentID = "0000",
							FirstName = "David", 
							MiddleName = "Wayne", 
							LastName = "Miller" 
						};
						
		Student s2 = new Student { StudentID = "0001" };	
		
		Student s3 = new Student("Svetlana", "Yuryevna", "Koroleva"){
							StudentID = "0002"
						};
		
		Console.WriteLine(p1);
		Console.WriteLine(s1);
		Console.WriteLine(s2);
		Console.WriteLine(s3);
		
		
		Student s4 = new Student();
		s4.StudentID = "0003";
		s4.FirstName = "Sarah";
		s4.MiddleName = "Sage";
		s4.LastName = "Silverman";
		
		Console.WriteLine(s4);
	}
}
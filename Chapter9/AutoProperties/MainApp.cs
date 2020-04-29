using System;

public class MainApp {
	public static void Main(){
	   Person p = new Person("Denise", "Marie", "Weber");
       Console.WriteLine("Person p's name is: " + p.FirstName + " " 
						+ p.MiddleName + " " + p.LastName);	   
	}
}
using System;

public class Student : Person {
	
	public string StudentID {
		get;
		set;
	}
	
	public Student(){}
	
	public Student(string firstName, string middleName, string lastName) : 
		base(firstName, middleName, lastName){}	
	
	public override string ToString(){
		return "Student ID: " + StudentID + " Name: " + FullName;
	}
}
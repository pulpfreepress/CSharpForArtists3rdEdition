using System;

public class Student : Person {
	
	public Student(string firstName, string middleName, string lastName) : 
		base(firstName, middleName, lastName){}	

    public void ChangeFirstAndMiddleNames(string firstName, string middleName){
		FirstName = firstName;
		MiddleName = middleName;
	}
}
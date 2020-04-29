using System;

public class Person {
	
	// Read-write properties
	public string FirstName {
	  get;
	  set;
	}
	
	public string MiddleName {
		get;
		set;
	}
	
	public string LastName {
		get;
		set;
	}
	
	
	public Person(string firstName, string middleName, string lastName){
		FirstName = firstName;
		MiddleName = middleName;
		LastName = lastName;
	}
	
} // end class
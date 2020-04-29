using System;
using System.Collections.Generic;

public class Person {
	
	// Read-write properties
	public string FirstName {
	  get;
	  set;
	} = "John";
	
	public string MiddleName {
		get;
		set;
	} = "Q";
	
	public string LastName {
		get;
		set;
	} = "Public";
	
	public List<Person> Relatives {
		get;
	} = new List<Person>();
	
	public Person(){}
	
	public Person(string firstName, string middleName, string lastName){
		FirstName = firstName;
		MiddleName = middleName;
		LastName = lastName;
	}
} // end class
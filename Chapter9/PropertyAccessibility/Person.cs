using System;
using System.Collections.Generic;

public class Person {
	
	// Public Read-write property
	public string FirstName {
	  get;
	  set;
	} = "John";
	
	// Public read - Protected write: Can be set in base and derived classes
	public string MiddleName {
		get;
		protected set;
	} = "Q";
	
	// Public read - Private write: Can be set in base class only
	public string LastName {
		get;
		private set;
	} = "Public";
	
	// Public Read-only - Can only be set by property initializer or in constructor
	public List<Person> Relatives {
		get;
	} = new List<Person>();
	
	public Person(){}
	
	public Person(string firstName, string middleName, string lastName){
		FirstName = firstName;			// OK, obviously
		MiddleName = middleName;		// OK
		LastName = lastName;			// OK
		Relatives = new List<Person>();	// redundant, but OK
	}
} // end class
using System;
using System.Collections.Generic;

public class Person {
	
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
	
	public string FullName {
		get { return FirstName + " " + MiddleName + " " + LastName; }
	}
	
	public List<Person> Relatives {
		get;
		set;
	} = new List<Person>();
	
	public Person(){}
	
	public Person(string firstName, string middleName, string lastName){
		FirstName = firstName;			
		MiddleName = middleName;		
		LastName = lastName;			
	}
	
	public override string ToString(){
		return FullName;
	}
} // end class
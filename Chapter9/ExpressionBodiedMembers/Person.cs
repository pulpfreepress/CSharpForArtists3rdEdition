using System;
using System.Collections.Generic;

public class Person {
	
	private string _firstName = "John";
	private string _middleName = "Q";
	private string _lastname = "Public";
	
	public string FirstName {
	  get => _firstName.ToUpper();
	  set => _firstName = value;
	}
	
	public string MiddleName {
		get => _middleName.ToUpper();
		set => _middleName = value;
	}
	
	public string LastName {
		get => _lastname.ToUpper();
		set => _lastname = value;
	}
	
	public string FullName => FirstName + " " + MiddleName + " " + LastName; 
	
	public List<Person> Relatives {
		get;
		set;
	} = new List<Person>();
	
	public Person(){}
	
	public Person(string firstName, string middleName, string lastName)
				  => (FirstName, MiddleName, LastName) = (firstName, middleName, lastName);
	
	public override string ToString() => FullName;
		
} // end class
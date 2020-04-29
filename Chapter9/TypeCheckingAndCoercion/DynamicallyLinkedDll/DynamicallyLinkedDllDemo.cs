using System;
using System.Reflection;


public class DynamicallyLinkedDllDemo {

    
	private int _toggle_type = 1;
	
	public object GetObjectFromLibrary(){
	  object return_val = null;
	  try{
		var lib = Assembly.Load("Student");
		Type[] exported_types = lib.GetExportedTypes();
		
		if(_toggle_type == 1){
			_toggle_type = 0;
		}else {
			_toggle_type = 1;
		}
		
		return_val = Activator.CreateInstance(exported_types[_toggle_type]);
	  }catch(Exception e){
		 Console.WriteLine(e);
		}
		
	  return return_val;
	}


	public static void Main(){
		DynamicallyLinkedDllDemo dldd = new DynamicallyLinkedDllDemo();
		
		/**** Get either Person or Student ****/
		dynamic obj1 = dldd.GetObjectFromLibrary();
		dynamic obj2 = dldd.GetObjectFromLibrary();
		
		/**** Getting object's type with GetType() ****/
		Console.WriteLine("------- Getting object's type with GetType() -------");
		Console.WriteLine("obj1 is type: " + obj1.GetType());
		Console.WriteLine("obj2 is type: " + obj2.GetType());
		
		Console.WriteLine("------- dynamic reference eliminates need to cast -------");
		obj1.FirstName = "Rick";
		obj2.FirstName = "John";
		Console.WriteLine("obj1 FirstName: " + obj1.FirstName);
		Console.WriteLine("obj2 FirstName: " + obj2.FirstName);
		
		/**** Get the type of each object ****/
		Type person = obj1.GetType();
		Type student = obj2.GetType();
		
		/**** Create a Person and Student object ****/
		dynamic p1 = Activator.CreateInstance(person);
		dynamic s1 = Activator.CreateInstance(student);
		p1.FirstName = "Sport";
		s1.FirstName = "Coralie";
		Console.WriteLine("p1 FirstName: " + p1.FirstName);
		Console.WriteLine("s1 FirstName: " + s1.FirstName);
		
		
	} // end Main()
} // end class
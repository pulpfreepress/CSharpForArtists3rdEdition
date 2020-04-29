using System;

public class StringsLikeArrays {
  public static void Main(){
	string s1 = "You can treat a string like an array!";
	
	//using the foreach statement
	foreach(char c in s1){
	  if(c != '!'){
	    Console.Write(c + "-");  
	  }else{
	     Console.WriteLine(c);
	  }
	}
	
	//using array indexing
	for(int i=0; i<s1.Length; i++){
	  if(s1[i] != '!'){
	    Console.Write(s1[i] + "-");
	  }else{
		Console.WriteLine(s1[i]);
	  }
	}	
  } // end Main()
} // end StringsLikeArrays class definition
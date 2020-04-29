/******************************************************
  Requires C# 7.2
*******************************************************/

using System;

public class LiteralReadability {
	
	public static void Main() {
	  
	  int i_hex = 0x00010FFF;
	  int i_bin = 0b00000000000000010000111111111111;
	  
	  Console.WriteLine(i_hex);
      Console.WriteLine(i_bin);
	  
	  i_hex = 0x0001_0FFF;
	  i_bin = 0b0000_0000_0000_0001_0000_1111_1111_1111;
	  
	  Console.WriteLine(i_hex);
      Console.WriteLine(i_bin);
	  
	  i_hex = 0x_0001_0FFF;
	  i_bin = 0b_0000_0000_0000_0001_0000_1111_1111_1111;
	  
	  Console.WriteLine(i_hex);
      Console.WriteLine(i_bin);
	}
}
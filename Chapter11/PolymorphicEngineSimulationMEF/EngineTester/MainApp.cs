using Engines;
using System;


namespace EngineTester {
	public class MainApp {
		private static void Main(string[] args) {
			Console.WriteLine("Instantiating Engine Object...");
			Engine e1 = new Engine(1);
			Console.WriteLine("----------------------------------------------------");
			Console.WriteLine("Reading Part Engine Numbers...");
			Console.WriteLine("OilPump Engine Number: {0}", e1.OilPumpEngineNumber);
			Console.WriteLine("FuelPump Engine Number: {0}", e1.FuelPumpEngineNumber);
			Console.WriteLine("Compressor Engine Number: {0}", e1.CompressorEngineNumber);
			Console.WriteLine("TemperatureSensor Engine Number: {0}",
				e1.TemperatureSensorEngineNumber);
			Console.WriteLine("OxygenSensor Engine Number: {0}", e1.OxygenSensorEngineNumber);
			Console.WriteLine("----------------------------------------------------");

			Console.WriteLine("\nPress Enter to Start Engine Number: {0}", e1.EngineNumber);
			Console.ReadKey();

			e1.StartEngine();

			Console.WriteLine("\nPress Enter to Set FuelPump Fault...");
			Console.ReadKey();

			e1.IsFuelPumpWorking = false;

			Console.WriteLine("\nPress Enter to Try to Start Engine Number: "
				+ "{0} with Faulty FuelPump", e1.EngineNumber);
			Console.ReadKey();

			e1.StartEngine();

			Console.WriteLine("\nPress Enter to Fix FuelPump and Restart Engine...");
			Console.ReadKey();

			e1.IsFuelPumpWorking = true;
			e1.StartEngine();

			Console.WriteLine("\nPress Enter to Stop Engine...");
			Console.ReadKey();

			e1.StopEngine();

			Console.WriteLine("\n\nPress Enter to Exit the Engine Demo...");
			Console.ReadKey();
		}
	}
}

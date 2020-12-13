using System;
using System.Collections.Generic;
using System.ComponentModel.Composition; // added
using System.ComponentModel.Composition.Hosting; // added
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engines;

namespace EngineTester
{
    public class MainApp
    {

        static void Main(string[] args)
        {
            Engine e1 = new Engine(1);
            Console.WriteLine("Oil Pump Engine Number: {0}", e1.OilPumpEngineNumber);
            Console.WriteLine("Fuel Pump Engine Number: {0}", e1.FuelPumpEngineNumber);
            Console.WriteLine("Compressor Engine Number: {0}", e1.CompressorEngineNumber);
            Console.WriteLine("Temperature Sensor Engine Number: {0}", e1.TemperatureSensorEngineNumber);
            Console.WriteLine("Oxygen Sensor Engine Number: {0}", e1.OxygenSensorEngineNumber);




            Console.Write("\n\n\nPress any key to continue...");
            Console.ReadKey();

            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }
    }
}

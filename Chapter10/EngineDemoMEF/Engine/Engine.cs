using System;
using System.Collections.Generic;
using System.ComponentModel.Composition; // added
using System.ComponentModel.Composition.Hosting; // added
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EngineParts;


namespace Engines
{
    [Export(typeof(Engine))]
    public class Engine
    {

        /***** Parts *****/
        [Import(typeof(OilPump))]
        public OilPump _oilPump;
       
        [Import(typeof(FuelPump))]
        private FuelPump _fuelPump;

        [Import(typeof(Compressor))]
        private Compressor _compressor;

        [Import(typeof(OxygenSensor))]
        private OxygenSensor _oxygenSensor;

        [Import(typeof(TemperatureSensor))]
        private TemperatureSensor _temperatureSensor;

        private CompositionContainer _container;

        /***** Properties *****/
        [Export]
        public int EngineNumber
        {
            get;
            set;
        }

        public bool IsRunning
        {
            get;
            set;
        } = false;

        public bool IsWorking
        {
            get
            {
                return _compressor.IsWorking && _oilPump.IsWorking && _fuelPump.IsWorking
                   && _temperatureSensor.IsWorking && _oxygenSensor.IsWorking;
            }
        }

        public int OilPumpEngineNumber
        {
            get { return _oilPump.EngineNumber;  }
        }

        public int FuelPumpEngineNumber
        {
            get { return _fuelPump.EngineNumber; }
        }

        public int CompressorEngineNumber
        {
            get { return _compressor.EngineNumber; }
        }

        public int TemperatureSensorEngineNumber
        {
            get { return _temperatureSensor.EngineNumber; }
        }

        public int OxygenSensorEngineNumber
        {
            get { return _oxygenSensor.EngineNumber; }
        }

        /***** Constructor *****/
        public Engine(int engine_number)
        {
            EngineNumber = engine_number;
            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(OilPump).Assembly));
            _container = new CompositionContainer(catalog);

            try
            {
                this._container.ComposeParts(this);
                

            } catch (Exception e)
            {
                Console.WriteLine(e);
            }

        } // end constructor

        public void SetCompressorStatus(PartStatus status) => _compressor.Status = status; 
        public void SetOilPumpStatus(PartStatus status) => _oilPump.Status = status;
        public void SetFuelPumpStatus(PartStatus status) => _fuelPump.Status = status;
        public void SetTemperatureSensorStatus(PartStatus status) => _temperatureSensor.Status = status;
        public void SetOxygenSensorStatus(PartStatus status) => _oxygenSensor.Status = status;
        
        
        public void StartEngine()
        {
            if(!IsRunning)
            {
                Console.WriteLine("Checking Engine No. {0} ", EngineNumber);
                if (IsWorking)
                {
                    Console.WriteLine("Starting Engine No. {0} ", EngineNumber);
                    IsRunning = true;
                    Console.WriteLine("Engine No. {0} is running!", EngineNumber);
                }
                else
                {
                    Console.WriteLine("Engine No. {0} has a problem. Check engine!", EngineNumber);
                }

            }
            else
            {
                Console.WriteLine("Engine No. {0} is already running!", EngineNumber);
            }
        } // end StartEngine()

        
        public void StopEngine()
        {
            IsRunning = false;
            Console.WriteLine("Engine No. {0} is shut down.", EngineNumber);
        }

    }
}

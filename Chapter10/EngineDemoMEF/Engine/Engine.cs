using EngineParts;
using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Text;


namespace Engines {
    [Export(typeof(Engine))]
    public class Engine {
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
        [Export] // Must be exported because it's used as a parameter to part constructors
        public int EngineNumber {
            get;
            set;
        }

        public bool IsRunning {
            get;
            set;
        } = false;

        public bool IsWorking {
            get {
                return _compressor.IsWorking && _oilPump.IsWorking && _fuelPump.IsWorking
                   && _temperatureSensor.IsWorking && _oxygenSensor.IsWorking;
            }
        }

        public int OilPumpEngineNumber {
            get { return _oilPump.EngineNumber; }
        }

        public int FuelPumpEngineNumber {
            get { return _fuelPump.EngineNumber; }
        }

        public int CompressorEngineNumber {
            get { return _compressor.EngineNumber; }
        }

        public int TemperatureSensorEngineNumber {
            get { return _temperatureSensor.EngineNumber; }
        }

        public int OxygenSensorEngineNumber {
            get { return _oxygenSensor.EngineNumber; }
        }

        public bool IsOilPumpWorking {
            get { return _oilPump.IsWorking; }
            set {
                _oilPump.IsWorking = value;
                if (!IsWorking) StopEngine();
            }
        }

        public bool IsFuelPumpWorking {
            get { return _fuelPump.IsWorking; }
            set {
                _fuelPump.IsWorking = value;
                if (!IsWorking) StopEngine();
            }
        }

        public bool IsCompressorWorking {
            get { return _compressor.IsWorking; }
            set {
                _compressor.IsWorking = value;
                if (!IsWorking) StopEngine();
            }
        }

        public bool IsTemperatureSensorWorking {
            get { return _temperatureSensor.IsWorking; }
            set {
                _temperatureSensor.IsWorking = value;
                if (!IsWorking) StopEngine();
            }
        }

        public bool IsOxygenSensorWorking {
            get { return _oxygenSensor.IsWorking; }
            set {
                _oxygenSensor.IsWorking = value;
                if (!IsWorking) StopEngine();
            }
        }

        /***** Constructor *****/
        public Engine(int engine_number) {
            EngineNumber = engine_number;
            // Check runtime directory for DLLs that contain parts with matching imports
            var catalog = new DirectoryCatalog(".");
            // Create the catalog
            _container = new CompositionContainer(catalog);

            try {
                this._container.ComposeParts(this);
            } catch (Exception e) {
                Console.WriteLine(e);
            }
        } // end constructor



        public string[] CheckEngine() {
            StringBuilder status_messages = new StringBuilder();
            if (_oilPump.IsWorking) status_messages.Append("OilPump -> Working,");
            else status_messages.Append("OilPump -> Falty,");

            if (_fuelPump.IsWorking) status_messages.Append("FuelPump -> Working,");
            else status_messages.Append("FuelPump -> Falty,");

            if (_compressor.IsWorking) status_messages.Append("Compressor -> Working,");
            else status_messages.Append("Compressor -> Falty,");

            if (_temperatureSensor.IsWorking) status_messages.Append("TemperatureSensor -> Working,");
            else status_messages.Append("TemperatureSensor -> Falty,");

            if (_oxygenSensor.IsWorking) status_messages.Append("OxygenSensor -> Working");
            else status_messages.Append("OxygenSensor -> Falty");

            return status_messages.ToString().Split(',');
        }


        public void StartEngine() {
            if (!IsRunning) {
                Console.WriteLine("Checking Engine No. {0} ", EngineNumber);
                if (IsWorking) {
                    Console.WriteLine("Starting Engine No. {0} ", EngineNumber);
                    IsRunning = true;
                    Console.WriteLine("Engine No. {0} is running!", EngineNumber);
                } else {
                    Console.WriteLine("Engine No. {0} has a problem...", EngineNumber);
                    foreach (string s in CheckEngine()) {
                        Console.WriteLine(s);
                    }
                }
            } else {
                Console.WriteLine("Engine No. {0} is already running!", EngineNumber);
            }
        } // end StartEngine()


        public void StopEngine() {
            IsRunning = false;
            Console.WriteLine("Engine No. {0} is shut down.", EngineNumber);
        }

    }
}

using EngineParts;
using Common;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.ReflectionModel;
using System.Text;


namespace Engines {
	[Export]
	public class Engine {
		/***** Part Fields *****/
		
		private IPart _oilPump;
		private IPart _fuelPump;
		private IPart _compressor;
		private IPart _oxygenSensor;
		private IPart _temperatureSensor;

		/***** Parts Container *****/
		private CompositionContainer _container;

		/**** Parts Collection *****/
		private HashSet<IPart> _parts;

		/***** Part Properties *****/

		[Import("IPart", typeof(OilPump))]
		public IPart OilPump {
			get { return _oilPump;  }
			set {
				_oilPump = value;
				_parts.Add(_oilPump);
			}
		}

		[Import("IPart", typeof(FuelPump))]
		public IPart FuelPump {
			get { return _fuelPump; }
			set {
				_fuelPump = value;
				_parts.Add(_fuelPump);
			}
		}

		[Import("IPart", typeof(Compressor))]
		public IPart Compressor {
			get { return _compressor; }
			set {
				_compressor = value;
				_parts.Add(_compressor);
			}
		}

		[Import("IPart", typeof(TemperatureSensor))]
		public IPart TemperatureSensor {
			get { return _temperatureSensor; }
			set {
				_temperatureSensor = value;
				_parts.Add(_temperatureSensor);
			}
		}

		[Import("IPart", typeof(OxygenSensor))]
		public IPart OxygenSensor {
			get { return _oxygenSensor; }
			set {
				_oxygenSensor = value;
				_parts.Add(_oxygenSensor);
			}
		}

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
		[ImportingConstructor]
		public Engine(int engine_number) {
			EngineNumber = engine_number;
			_parts = new HashSet<IPart>();
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
			Console.WriteLine("CheckEngine() method called...");
			StringBuilder status_messages = new StringBuilder();

			foreach(IPart part in _parts) {
				if (part.IsWorking) {
						status_messages.Append(part + " is working!,");
				} else {
					status_messages.Append(part + " is faulty!,");
				}
			}
				
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

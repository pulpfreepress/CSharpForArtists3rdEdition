using Common;
using EngineParts;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;
using System.Text;


namespace Engines {

	[Export]
	public class Engine {

		/***** Private Part Fields *****/
		private IPart _oilPump;
		private IPart _fuelPump;
		private IPart _compressor;
		private IPart _oxygenSensor;
		private IPart _temperatureSensor;

		/***** Part Properties *****/
		[Import(typeof(OilPump))]
		public IPart OilPump {
			get { return _oilPump; }
			set {
				_oilPump = value;
			}
		}

		[Import(typeof(FuelPump))]
		public IPart FuelPump {
			get { return _fuelPump; }
			set {
				_fuelPump = value;
			}
		}

		[Import(typeof(Compressor))]
		public IPart Compressor {
			get { return _compressor; }
			set {
				_compressor = value;
			}
		}

		[Import(typeof(TemperatureSensor))]
		public IPart TemperatureSensor {
			get { return _temperatureSensor; }
			set {
				_temperatureSensor = value;
			}
		}

		[Import(typeof(OxygenSensor))]
		public IPart OxygenSensor {
			get { return _oxygenSensor; }
			set {
				_oxygenSensor = value;
			}
		}

		/***** MEF Parts Container *****/
		private CompositionContainer _container;

		/***** List of IParts *****/
		private List<IPart> _parts;

		/***** Public Properties *****/
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
				return CheckEngine().IsWorking;
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
			get { return OilPump.IsWorking; }
			set {
				OilPump.IsWorking = value;
				if (!OilPump.IsWorking) StopEngine();
			}
		}

		public bool IsFuelPumpWorking {
			get { return FuelPump.IsWorking; }
			set {
				FuelPump.IsWorking = value;
				if (!FuelPump.IsWorking) StopEngine();
			}
		}

		public bool IsCompressorWorking {
			get { return Compressor.IsWorking; }
			set {
				Compressor.IsWorking = value;
				if (!Compressor.IsWorking) StopEngine();
			}
		}

		public bool IsTemperatureSensorWorking {
			get { return TemperatureSensor.IsWorking; }
			set {
				TemperatureSensor.IsWorking = value;
				if (!TemperatureSensor.IsWorking) StopEngine();
			}
		}

		public bool IsOxygenSensorWorking {
			get { return OxygenSensor.IsWorking; }
			set {
				OxygenSensor.IsWorking = value;
				if (!OxygenSensor.IsWorking) StopEngine();
			}
		}

		/***** Constructor *****/
		[ImportingConstructor]
		public Engine(int engine_number) {
			EngineNumber = engine_number;
			try {
				// Check runtime directory for DLLs that contain parts with matching imports
				var catalog = new DirectoryCatalog(".");
				// Create the catalog
				_container = new CompositionContainer(catalog);
				this._container.ComposeParts(this);
				_parts = GetParts();
			} catch (Exception e) {
				Console.WriteLine(e);
			}
		} // end constructor


		public (bool IsWorking, string[] StatusMessages) CheckEngine() {
			Console.WriteLine("CheckEngine() method called...");
			StringBuilder status_messages = new StringBuilder();
			bool working = true;
			// Check each engine property
			foreach (IPart part in _parts) {
				if (part.IsWorking) {
					status_messages.Append(part + " -> working!,");
				} else {
					status_messages.Append(part + " -> faulty!,");
					working = false;
				}
			}
			return (working, status_messages.ToString().Split(','));
		}


		public void StartEngine() {
			Console.WriteLine("Checking Engine No. {0} ", EngineNumber);
			var (isworking, statusmessages) = CheckEngine();
			if (!IsRunning) {
				if (isworking) {
					Console.WriteLine("Starting Engine No. {0} ", EngineNumber);
					IsRunning = true;
					Console.WriteLine("Engine No. {0} is running!", EngineNumber);
				} else {
					Console.WriteLine("Engine No. {0} has a problem...", EngineNumber);
					foreach (string s in statusmessages) {
						Console.WriteLine(s);
					}
				}
			} else {
				Console.WriteLine("Engine No. {0} is already running!", EngineNumber);
			}
		} // end StartEngine()


		public void StopEngine() {
			Console.WriteLine("Stopping Engine No. {0} ", EngineNumber);
			IsRunning = false;
			foreach (string s in CheckEngine().StatusMessages) {
				Console.WriteLine(s);
			}
			Console.WriteLine("Engine No. {0} is shut down.", EngineNumber);
		}

		private List<IPart> GetParts() {
			List<IPart> parts = new List<IPart>();
			foreach (PropertyInfo prop in this.GetType().GetProperties()) {
				if (prop.PropertyType == typeof(IPart)) {
					parts.Add((IPart)prop.GetValue(this));
				}
			}
			return parts;
		}

	} // end class 
} // end namespace

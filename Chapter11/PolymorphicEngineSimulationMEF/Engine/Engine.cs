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
	public class Engine : IEngine {

		/***** Private Part Fields *****/
		private EnginePart _oilPump;
		private EnginePart _fuelPump;
		private EnginePart _compressor;
		private EnginePart _oxygenSensor;
		private EnginePart _temperatureSensor;

		/***** Part Properties *****/
		[Import(typeof(OilPump))]
		public EnginePart OilPump {
			get { return _oilPump; }
			set {
				_oilPump = value;
			}
		}

		[Import(typeof(FuelPump))]
		public EnginePart FuelPump {
			get { return _fuelPump; }
			set {
				_fuelPump = value;
			}
		}

		[Import(typeof(Compressor))]
		public EnginePart Compressor {
			get { return _compressor; }
			set {
				_compressor = value;
			}
		}

		[Import(typeof(TemperatureSensor))]
		public EnginePart TemperatureSensor {
			get { return _temperatureSensor; }
			set {
				_temperatureSensor = value;
			}
		}

		[Import(typeof(OxygenSensor))]
		public EnginePart OxygenSensor {
			get { return _oxygenSensor; }
			set {
				_oxygenSensor = value;
			}
		}

		/***** MEF Parts Container *****/
		private CompositionContainer _container;

		/***** List of IParts *****/
		private List<EnginePart> _parts;

		/***** Public Properties *****/
		[Export]
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
			get { return _oilPump.RegisteredEngine.EngineNumber; }
		}

		public int FuelPumpEngineNumber {
			get { return _fuelPump.RegisteredEngine.EngineNumber; }
		}

		public int CompressorEngineNumber {
			get { return _compressor.RegisteredEngine.EngineNumber; }
		}

		public int TemperatureSensorEngineNumber {
			get { return _temperatureSensor.RegisteredEngine.EngineNumber; }
		}

		public int OxygenSensorEngineNumber {
			get { return _oxygenSensor.RegisteredEngine.EngineNumber; }
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
				foreach (EnginePart part in _parts) {
					part.RegisteredEngine = this;
				}
			} catch (Exception e) {
				Console.WriteLine(e);
			}
		} // end constructor


		public (bool IsWorking, string[] StatusMessages) CheckEngine() {
			Console.WriteLine("CheckEngine() method called...");
			StringBuilder status_messages = new StringBuilder();
			bool working = true;
			// Check each engine property
			foreach (EnginePart part in _parts) {
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
			if (!IsRunning) {
				if (IsWorking) {
					Console.WriteLine("Starting Engine No. {0} ", EngineNumber);
					IsRunning = true;
					Console.WriteLine("Engine No. {0} is running!", EngineNumber);
				} else {
					Console.WriteLine("Engine No. {0} has a problem...", EngineNumber);
					foreach (string s in CheckEngine().StatusMessages) {
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
			Console.WriteLine("Engine No. {0} is shut down.", EngineNumber);
		}

		private List<EnginePart> GetParts() {
			List<EnginePart> parts = new List<EnginePart>();
			foreach (PropertyInfo prop in this.GetType().GetProperties()) {
				if (prop.PropertyType == typeof(EnginePart)) {
					parts.Add((EnginePart)prop.GetValue(this));
				}
			}
			return parts;
		}

	} // end class 
} // end namespace

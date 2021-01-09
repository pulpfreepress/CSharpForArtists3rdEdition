using System;
using Common;
using System.ComponentModel.Composition;

namespace EngineParts {

	[Export(typeof(IPart))]
	[Export(typeof(FuelPump))]
	public class FuelPump : IPart {
		public int EngineNumber {
			get;
			set;
		}

		public PartStatus Status {
			get;
			set;
		} = PartStatus.WORKING;

		public bool IsWorking {
			get {
				return Status == PartStatus.WORKING ? true : false;
			}
			set {
				if (value) Status = PartStatus.WORKING;
				else Status = PartStatus.NOT_WORKING;
			}
		}

		[ImportingConstructor]
		public FuelPump(int engine_number) {
			EngineNumber = engine_number;
			Console.WriteLine(this.GetType().Name + " Created!");
		}
	}
}

using Common;
using System;
using System.ComponentModel.Composition;

namespace EngineParts {

	[Export(typeof(FuelPump))]
	public class FuelPump : EnginePart {

		[ImportingConstructor]
		public FuelPump() : base("FuelPump") {
			Console.WriteLine(this.GetType().Name + " Created!");
		}
	}
}

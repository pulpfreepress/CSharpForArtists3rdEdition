using Common;
using System;
using System.ComponentModel.Composition;

namespace EngineParts {

	[Export(typeof(OxygenSensor))]
	public class OxygenSensor : EnginePart {

		[ImportingConstructor]
		public OxygenSensor() : base("OxygenSensor") {
			Console.WriteLine(this.GetType().Name + " Created!");
		}
	}
}

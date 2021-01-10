using Common;
using System;
using System.ComponentModel.Composition;

namespace EngineParts {

	[Export(typeof(TemperatureSensor))]
	public class TemperatureSensor : EnginePart {

		[ImportingConstructor]
		public TemperatureSensor() : base("TemperatureSensor") {
			Console.WriteLine(this.GetType().Name + " Created!");
		}
	}
}

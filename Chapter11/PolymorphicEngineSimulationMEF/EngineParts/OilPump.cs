using Common;
using System;
using System.ComponentModel.Composition;

namespace EngineParts {

	[Export(typeof(OilPump))]
	public class OilPump : EnginePart {

		[ImportingConstructor]
		public OilPump() : base("OilPump") {
			Console.WriteLine(this.GetType().Name + " Created!");
		}
	}
}

using Common;
using System;
using System.ComponentModel.Composition;

namespace EngineParts {

	[Export(typeof(Compressor))]
	public class Compressor : EnginePart {

		[ImportingConstructor]
		public Compressor() : base("Compressor") {
			Console.WriteLine(this.GetType().Name + " Created!");
		}
	}
}

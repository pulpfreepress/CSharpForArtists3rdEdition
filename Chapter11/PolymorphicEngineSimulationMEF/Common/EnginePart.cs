using System;

namespace Common {

	public abstract class EnginePart : Part, IManagedPart {

		public IEngine RegisteredEngine {
			get;
			set;
		}

		public string PartIdentifier {
			get {
				return Name + " for Engine No. " + RegisteredEngine.EngineNumber;
			}
		}

		public EnginePart(string name) : base(name) {

		}

		public void SetFault() {
			IsWorking = false;
			DisplayStatus();
			RegisteredEngine.StopEngine();
			
		}

		public void ClearFault() {
			IsWorking = true;
			DisplayStatus();
		}

		private void DisplayStatus() {
			Console.WriteLine(PartIdentifier + " is now " + Status);
		}

	} // end class
} // end namespace

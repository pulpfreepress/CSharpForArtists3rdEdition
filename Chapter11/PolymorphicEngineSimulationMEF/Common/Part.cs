namespace Common {

	public abstract class Part : IPart {

		public string Name {
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

		public Part(string name) {
			Name = name;
		}

		public override string ToString() {
			return Name;
		}

	} // end class
} // end namespace

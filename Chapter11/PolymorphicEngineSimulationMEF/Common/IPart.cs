namespace Common {

	public interface IPart {

		string Name {
			get;
			set;
		}

		PartStatus Status {
			get;
			set;
		}

		bool IsWorking {
			get;
			set;
		}
	}
}

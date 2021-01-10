namespace Common {

	public interface IPart {
		int EngineNumber {
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

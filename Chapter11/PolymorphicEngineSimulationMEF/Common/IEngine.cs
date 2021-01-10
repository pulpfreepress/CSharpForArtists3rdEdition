namespace Common {
	public interface IEngine {
		int EngineNumber {
			get;
			set;
		}

		bool IsRunning {
			get;
			set;
		}

		bool IsWorking {
			get;
		}

		(bool IsWorking, string[] StatusMessages) CheckEngine();
		void StartEngine();
		void StopEngine();
	}
}

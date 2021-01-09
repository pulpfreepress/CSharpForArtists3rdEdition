using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

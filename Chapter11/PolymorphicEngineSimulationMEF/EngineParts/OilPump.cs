﻿using Common;
using System;
using System.ComponentModel.Composition;

namespace EngineParts {

	[Export(typeof(OilPump))]
	public class OilPump : IPart {
		public int EngineNumber {
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

		[ImportingConstructor]
		public OilPump(int engine_number) {
			EngineNumber = engine_number;
			Console.WriteLine(this.GetType().Name + " Created!");
		}

		public override string ToString() {
			return "OilPump";
		}
	}
}
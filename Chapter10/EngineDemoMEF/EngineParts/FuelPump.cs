using System;
using System.Collections.Generic;
using System.ComponentModel.Composition; // added
using System.ComponentModel.Composition.Hosting; // added
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineParts
{
    [Export(typeof(FuelPump))]
    public class FuelPump
    {
        public int EngineNumber
        {
            get;
            set;
        }

        public PartStatus Status
        {
            get;
            set;
        } = PartStatus.WORKING;

        public bool IsWorking
        {
            get
            {
                return Status == PartStatus.WORKING ? true : false;
            }
        }

        [ImportingConstructor]
        public FuelPump(int engine_number)
        {
            EngineNumber = engine_number;
            Console.WriteLine(this.GetType().Name + " Created!");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfrastructureLayer;
using Subscriber;

namespace PresentationLayer {
	class MainApp {
		static void Main(string[] args) {
			Person p = new Person();
			p.FirstName = "Rick";
			p.LastName = "Miller";

			Console.WriteLine(p.ToJSON());

			Console.ReadKey();
			
		}
	}
}

using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Web.Script.Serialization;

namespace InfrastructureLayer {
	public class Person : INotifyPropertyChanged {

		// Fields
		private string _firstName;
		private string _lastName;

		public event PropertyChangedEventHandler PropertyChanged;

		public string FirstName {
			get { return _firstName; }
			set {
				if (value != _firstName) {
					_firstName = value;
					this.NotifyPropertyChanged();
				}
			}
		}

		public string LastName {
			get { return _lastName; }
			set {
				if (value != _lastName) {
					_lastName = value;
					this.NotifyPropertyChanged();
				}
			}
		}


		private void NotifyPropertyChanged([CallerMemberName] string propertyName = "") {
			if(PropertyChanged != null) {
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}


		public override string ToString() {
			return FirstName + " " + LastName;
		}

		public string ToJSON() {
			return new JavaScriptSerializer().Serialize(this).ToString();
		}

	} // end class
} // end namespace

using System;
using System.Windows;
using System.Windows.Input;

namespace PresentationLayer.Windows {
	/// <summary>
	/// Interaction logic for Intro.xaml
	/// </summary>
	public partial class Intro : Window {
		public Intro() {
			InitializeComponent();
			SplashMovie.Source = new Uri(Properties.Resources.splash_movie, UriKind.RelativeOrAbsolute);
			SplashMovie.Play();
		}

		private void Window_MouseDown(object sender, MouseButtonEventArgs e) {
			this.Close();
		}
	}
}

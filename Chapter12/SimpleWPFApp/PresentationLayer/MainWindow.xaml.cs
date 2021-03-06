using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows;
using System.Drawing;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PresentationLayer {
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window {
		public MainWindow() {
			InitializeComponent();
			
		}

		private void Window_Loaded(object sender, EventArgs e) {
			ShowIntroWindow();
		}

		private void Show_Splash_Image(object sender, EventArgs e) {
			ShowSplashImage();
		}

		private void Show_Intro_Window(object sender, EventArgs e) {
			ShowIntroWindow();
		}


		private void Goto_PulpFreePress(object sender, EventArgs e) {
					System.Diagnostics.Process.Start(@"https://pulpfreepress.com");
		}

		private void ShowIntroWindow() {
			try {
				Window intro = new Windows.Intro();
				intro.Owner = this;
				intro.ShowDialog();
			} catch (Exception) {
				Console.WriteLine("Problem loading Intro Window");
			}
		}


		private void ShowSplashImage() {
			BitmapImage img = new BitmapImage();
			img.BeginInit();
			img.UriSource = new Uri((string)Application.Current.Resources["splash_image"], UriKind.RelativeOrAbsolute);
			img.EndInit();
			SplashScreen sc = new SplashScreen(img.UriSource.ToString());
			sc.Show(false, true);
			Thread.Sleep(600);
			sc.Close(TimeSpan.FromSeconds(5));
		}

		



	} // End class
}

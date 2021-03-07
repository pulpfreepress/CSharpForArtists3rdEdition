using System;
using System.Threading;
using System.Windows;
using System.Windows.Media.Imaging;

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

		private void Window_MouseDown(object sender, EventArgs e) {
			ShowSplashImage();
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
			img.UriSource = new Uri((string)Application.Current.Resources["splash_image"],
											UriKind.RelativeOrAbsolute);
			img.EndInit();
			SplashScreen sc = new SplashScreen(img.UriSource.ToString());
			sc.Show(false, true); //autoClose:false, topMost:true
			Thread.Sleep(600);
			sc.Close(TimeSpan.FromSeconds(5));
		}

	} // End class
}

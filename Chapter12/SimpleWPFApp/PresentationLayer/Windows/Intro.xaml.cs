using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PresentationLayer.Windows
{
    /// <summary>
    /// Interaction logic for Intro.xaml
    /// </summary>
    public partial class Intro : Window
    {
        public Intro()
        {
						InitializeComponent();
						SplashMovie.Source = new Uri(Properties.Resources.splash_movie, UriKind.RelativeOrAbsolute);
						SplashMovie.Play();
            
						
        }

	

		private void Window_MouseDown(object sender, MouseButtonEventArgs e) {
			this.Close();
		}
	}
}

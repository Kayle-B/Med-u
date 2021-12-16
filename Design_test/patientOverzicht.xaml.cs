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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Design_test
{
    /// <summary>
    /// Interaction logic for patientOverzicht.xaml
    /// </summary>
    public partial class patientOverzicht : Page
    {
        public patientOverzicht()
        {
            InitializeComponent();
        }

        private void homepageBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }

        private void patientOverzichtBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void closeHamburgerMenuBtn_Click(object sender, RoutedEventArgs e)
        {
            if (hamburgerMenu.Visibility != Visibility.Collapsed)
            {
                hamburgerMenu.Visibility = Visibility.Collapsed;
            }
        }

        private void openHamburgerMenuBtn_Click(object sender, RoutedEventArgs e)
        {
            if (hamburgerMenu.Visibility == Visibility.Collapsed)
            {
                hamburgerMenu.Visibility = Visibility.Visible;
            }
        }
    }
}

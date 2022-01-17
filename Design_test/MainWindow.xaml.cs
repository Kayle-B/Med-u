using System.Windows;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SQLServer sqlserver = new SQLServer();
        public Doctor doctor;

        public MainWindow()
        {
            InitializeComponent();
            // Set is so that the hamburger menu is closed on start
            hamburgerMenu.Visibility = Visibility.Collapsed;
            openHamburgerMenuBtn.Visibility = Visibility.Collapsed;
            Main.Content = new LoginPage(Main, sqlserver);
        }

        private void closeHamburgerMenuBtn_Click(object sender, RoutedEventArgs e)
        {
            // if the menu is close button is pressed close if its not closed already
            if (hamburgerMenu.Visibility != Visibility.Collapsed)
            {
                hamburgerMenu.Visibility = Visibility.Collapsed;
            }
        }

        private void openHamburgerMenuBtn_Click(object sender, RoutedEventArgs e)
        {
            // if the menu is open button is pressed open if its not open already
            if (hamburgerMenu.Visibility == Visibility.Collapsed)
            {
                hamburgerMenu.Visibility = Visibility.Visible;
            }
        }

        private void homepageBtn_Click(object sender, RoutedEventArgs e)
        {
            //redirect the content to homepage iwth the data of this main and the sqlserver class
            Main.Content = new homePage(this.Main, this.sqlserver);
            hamburgerMenu.Visibility = Visibility.Collapsed;
        }

        private void patientOverzichtBtn_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new homePage(this.Main, this.sqlserver);
            hamburgerMenu.Visibility = Visibility.Collapsed;
        }

        private void patientToevoegenBtn_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new addPatientPage(this.Main, doctor);
            hamburgerMenu.Visibility = Visibility.Collapsed;
        }

        private void instellingBtn_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new _404Page();
            hamburgerMenu.Visibility = Visibility.Collapsed;
        }

        private void helpBtn_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new _404Page();
            hamburgerMenu.Visibility = Visibility.Collapsed;
        }

        private void Main_ContentRendered(object sender, EventArgs e)
        {
            if (Main.Content.ToString() != "Design_test.LoginPage")
            {
                openHamburgerMenuBtn.Visibility = Visibility.Visible;
            }
        }

        private void logoutBtn_Click(object sender, RoutedEventArgs e)
        {
            // making it so that the existing doctor becomes a new doctor with no data. 
            doctor = new Doctor();
            Main.Content = new LoginPage(Main, sqlserver);
            hamburgerMenu.Visibility = Visibility.Collapsed;
            openHamburgerMenuBtn.Visibility = Visibility.Collapsed;
        }
    }
}

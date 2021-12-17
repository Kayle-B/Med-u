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
        public MainWindow()
        {
            InitializeComponent();
            LoginPage loginpage = new LoginPage();
            this.Content = loginpage;
/*            hamburgerMenu.Visibility = Visibility.Collapsed;
*/            SQLServer setup = new SQLServer();
        }

/*        private void closeHamburgerMenuBtn_Click(object sender, RoutedEventArgs e)
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
        }*/

        private void addPatientButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void homepageBtn_Click(object sender, RoutedEventArgs e)
        {
            homePage homePage = new homePage();
            this.Content = homePage;
        }

        private void patientOverzichtBtn_Click(object sender, RoutedEventArgs e)
        {
            patientOverzicht patientOverzicht = new patientOverzicht();
            this.Content = patientOverzicht;
        }

/*        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string connString = "Data Source=localhost;Initial Catalog = pf2; User ID = root; Password=";
            string query = "SELECT * FROM users";

            try
            {
                MySqlConnection conn = new MySqlConnection(connString);
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    MessageBox.Show(reader.GetString(0)); 
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }*/
    }
}

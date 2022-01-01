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
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        SQLServer sqlserver;
        System.Windows.Controls.Frame main;
        Doctor doctor = new Doctor();

        public LoginPage(System.Windows.Controls.Frame main, SQLServer sqlserver, Doctor doctor)
        {
            InitializeComponent();
            this.main = main;
            this.sqlserver = sqlserver;
            this.doctor = doctor;

        }

        private void loginBtn(object sender, RoutedEventArgs e)
        {
            var mWindow = (MainWindow)Application.Current.MainWindow;

            sqlserver.openConnection();

            doctor = new Doctor(usernameTextBox.Text, passwordTextBox.Text);
            // Use alternate login otherwise doctor cannot get passed to main
            doctor = doctor.alternateLoginDoctor(usernameTextBox.Text, passwordTextBox.Text);

            if (doctor.id != null)
            {
                doctor.loadPatients();
                mWindow.doctor = doctor;
                this.main.Content = new homePage(main, this.sqlserver);

            }
            else
            {
                MessageBox.Show("Geen dokter met die inloggegevens gevonden");
            }
        }
    }
}

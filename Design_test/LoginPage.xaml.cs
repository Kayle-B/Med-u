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
        Doctor doctor;
        
        public LoginPage(System.Windows.Controls.Frame main, SQLServer sqlserver, Doctor doctor)
        {
            InitializeComponent();
            this.main = main;
            this.sqlserver = sqlserver;
            this.doctor = doctor;
        }
        
        private void loginBtn(object sender, RoutedEventArgs e)
        {
            sqlserver.openConnection();

            doctor = new Doctor(usernameTextBox.Text, passwordTextBox.Text);
            // Use alternate login otherwise doctor cannot get passed to main
            doctor = doctor.alternateLoginDoctor(usernameTextBox.Text, passwordTextBox.Text);

            if (doctor.id != null)
            {
                doctor.loadPatients();
                main.Content = new homePage(main, this.sqlserver, doctor);
            }
            else
            {
                MessageBox.Show("Geen dokter met die inloggegevens gevonden");
            }
        }
    }
}

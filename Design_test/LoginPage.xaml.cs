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
        SQLServer sqlserver = new SQLServer();
        
        public LoginPage()
        {
            InitializeComponent();
        }

        private void loginBtn(object sender, RoutedEventArgs e)
        {
            sqlserver.openConnection();
            Doctor doctor = sqlserver.loginDoctor(usernameTextBox.Text, passwordTextBox.Text);
            if (doctor != null)
            {
                doctor.getPatientForDoctor();

                /*AFTER LOGIN LOAD NEW PAGE*/
            }
            else
            {
                MessageBox.Show("No doctor found with those credentials");
            }

        }
    }
}

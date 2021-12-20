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
        
        public LoginPage(System.Windows.Controls.Frame main, SQLServer sqlserver)
        {
            InitializeComponent();
            this.main = main;
            this.sqlserver = sqlserver;
        }
        
        private void loginBtn(object sender, RoutedEventArgs e)
        {
            sqlserver.openConnection();
            sqlserver.doctor = sqlserver.loginDoctor(usernameTextBox.Text, passwordTextBox.Text);
            if (sqlserver.doctor != null)
            {
                sqlserver.doctor.getPatientForDoctor();
                main.Content = new homePage(main, this.sqlserver, sqlserver.doctor);
            }
            else
            {
                MessageBox.Show("No doctor found with those credentials");
            }

        }
    }
}

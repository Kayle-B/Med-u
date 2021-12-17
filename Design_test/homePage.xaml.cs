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
using MySql.Data.MySqlClient;

namespace Design_test
{
    /// <summary>
    /// Interaction logic for homePage.xaml
    /// </summary>
    public partial class homePage : Page
    {
        MySqlDataReader reader;
        SQLServer sQLConnection = new SQLServer();
        List<Patient> patients = new List<Patient>();

        public homePage()
        {
            InitializeComponent();
            sQLConnection.openConnection();
            patientCountLabel.Content = sQLConnection.getPatientCount();
        }

        private void addPatientButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(patientTextBox.Text != null)
            {
                patients = sQLConnection.getPatientList(patientTextBox.Text);
                foreach (var patient in patients)
                {
/*                    MessageBox.Show(string.Format("{0}, {1}, {2}, {3}, {4}", patient.gender, patient.email, patient.phone, patient.gender, patient.age));
*/                }
            }
        }
    }
}

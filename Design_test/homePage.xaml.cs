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
        Doctor doctor;
        SQLServer sQLServer;
        List<Patient> searchPatient = new List<Patient>();


        public homePage(SQLServer sQLServer, Doctor doctor)
        {
            InitializeComponent();
            this.sQLServer = sQLServer;
            this.doctor = doctor;
            patientCountLabel.Content = doctor.Patients.Count();
        }

        private void addPatientButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (patientTextBox.Text != "")
            {
                foreach (var patient in doctor.Patients)
                {
                    if (patient.name.ToLower().Contains(patientTextBox.Text.ToLower()))
                    {
                        MessageBox.Show(patient.name);
                    }

                }
            }
        }

        private void patientTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}

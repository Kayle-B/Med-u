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
    /// Interaction logic for editPatient.xaml
    /// </summary>
    public partial class editPatient : Page
    {
        SQLServer sQLServer = new SQLServer();
        Patient patient;
        string query;

        int id;
        string salutation;
        string name;
        string lastname;
        string insertion;
        string email;
        string phone;
        string BSN;
        string allergies;


        public editPatient(int id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            patient = new Patient(id, name, lastname);
            this.patient = patient.getPatient(id);
            

            naamTextBox.Text = patient.name;
            achternaamTextBox.Text = patient.lastname;
        }

        private void updatePatientBtn_Click(object sender, RoutedEventArgs e)
        {
            patient.updatePatient(this.id, naamTextBox.Text, achternaamTextBox.Text);
            MessageBox.Show("Changed patient");
        }
    }
}

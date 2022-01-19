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
    public partial class editPatientPage : Page
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


        public editPatientPage(int id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            patient = new Patient();
            patient.getPatient(id);
            firstnameTextBox.Text = patient.firstname;
            lastnameTextBox.Text = patient.lastname;
            prefixTextBox.Text = patient.prefix;
            salutationTextBox.Text = patient.salutation;
            emailTextBox.Text = patient.email;
            phoneTextBox.Text = patient.phone;
            allergyTextBox.Text = patient.allergies;
            bsnTextBox.Text = patient.bsn;
        }

        private void updatePatientBtn_Click(object sender, RoutedEventArgs e)
        {
            string salutation = salutationTextBox.Text;
            string firstname = firstnameTextBox.Text;
            string lastname = lastnameTextBox.Text;
            string prefix = prefixTextBox.Text;
            string email = emailTextBox.Text;
            string phone = phoneTextBox.Text;
            string BSN = bsnTextBox.Text;
            string allergies = allergyTextBox.Text;

            patient = new Patient(this.id, firstname, firstname, lastname, salutation, prefix, BSN, email, phone, allergies);


            patient.updatePatient();
            MessageBox.Show("Changed patient");
        }
    }
}

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
    public partial class addPatient : Page
    {
        string name;
        string[] split;
        SQLServer sQLServer = new SQLServer();
        Doctor doctor;
        Patient patient;


        public addPatient(string name, Doctor doctor)
        {
            InitializeComponent();
            this.name = name;
            this.doctor = doctor;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (name != "")
            {
                if (name.Contains(" "))
                {
                     split = name.Split(' ');
                    firstnameTextBox.Text = split[0];
                    lastnameTextBox.Text = split[1];
                }
                else
                {
                    firstnameTextBox.Text = name;
                }
            }
        }

        private void savePatientBtn_Click(object sender, RoutedEventArgs e)
        {
            string salutation = salutationTextBox.Text;
            string firstname = firstnameTextBox.Text;
            string lastname = lastnameTextBox.Text;
            string prefix = prefixTextBox.Text;
            string email = emailTextBox.Text;
            string phone = phoneTextBox.Text;
            string BSN = bsnTextBox.Text;
            string allergies = allergyTextBox.Text;

            patient = new Patient(0, firstname, firstname, lastname, salutation, prefix, 20, BSN,  email,  phone,  allergies, this.doctor.id);



            if (firstname == "" || lastname == "" || email == "" || BSN == "")
            {
                MessageBox.Show("Zorg ervoor dat u alles invuld!");
                return;
            }
            else
            {
                string query = string.Format("SELECT * FROM patient WHERE first_name = '{0}' && last_name='{1}';", firstname, lastname);

                if (sQLServer.executeQeury(query).HasRows != true)
                {
                    patient.savePatient(patient);
                    MessageBox.Show("Patient toegevoegd");
                }
                else
                {
                    MessageBox.Show("Patient bestaat al");
                }
            }
        }
    }
}

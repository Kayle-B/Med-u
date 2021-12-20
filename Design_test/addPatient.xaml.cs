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
                    naamTextBox.Text = split[0];
                    achternaamTextBox.Text = split[1];
                }
                else
                {
                    naamTextBox.Text = name;
                }
            }
        }

        private void savePatientBtn_Click(object sender, RoutedEventArgs e)
        {
            string salutation = aanhefTextBox.Text;
            string name = naamTextBox.Text;
            string lastname = achternaamTextBox.Text;
            string insertion = voegselTextBox.Text;
            string email = emailTextBox.Text;
            string phone = telefoonTextBox.Text;
            string BSN = bsnTextBox.Text;
            string allergies = allergieenTextBox.Text;

            patient = new Patient(0, name, lastname);



            if (name == "" || lastname == "" || email == "" || phone == "" || BSN == "")
            {
                MessageBox.Show("Zorg ervoor dat u alles invuld!");
                return;
            }
            else
            {
                string query = string.Format("SELECT * FROM patient WHERE name = '{0}' && lastname='{1}';", name, lastname);
                

                if (sQLServer.executeQeury(query).HasRows != true)
                {
                    patient.savePatient(name, lastname, this.doctor.id);
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

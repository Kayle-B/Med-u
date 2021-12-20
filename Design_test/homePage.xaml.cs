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
        System.Windows.Controls.Frame main;
        List<int> searchedId = new List<int>();


        public homePage(System.Windows.Controls.Frame main, SQLServer sQLServer, Doctor doctor)
        {
            InitializeComponent();
            this.main = main;
            this.sQLServer = sQLServer;
            this.doctor = doctor;
            patientCountLabel.Content = doctor.Patients.Count();
        }

        private void addPatientButton_Click(object sender, RoutedEventArgs e)
        {
            string name = addPatientTextbox.Text;
            main.Content = new addPatient(name, doctor);
        }

        private void patientTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            userNameLabel.Content = doctor.name;
        }

        private void patientComboBox_KeyUp(object sender, KeyEventArgs e)
        {
            searchedId.Clear();
            if (patientComboBox.Text != null)
            {
                patientComboBox.Items.Clear();
                doctor.getPatientForDoctor();
                if (patientComboBox.Text != "")
                {
                    foreach (var patient in doctor.Patients)
                    {
                        if (patient.name.ToLower().Contains(patientComboBox.Text.ToLower()))
                        {
                            searchedId.Add(patient.id);
                            patientComboBox.Items.Add(patient.name);
                            patientComboBox.IsDropDownOpen = true;
                        }
                    }
                }
            }
        }

        private void patientComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (patientComboBox.SelectedItem == null)
            {
                zNameRectangle.Height = 120;
                detailBtn.Visibility = Visibility.Hidden;
                medListBtn.Visibility = Visibility.Hidden;
            }
            else
            {
                zNameRectangle.Height = 150;
                detailBtn.Visibility = Visibility.Visible;
                medListBtn.Visibility = Visibility.Visible;
            }
        }

        private void detailBtn_Click(object sender, RoutedEventArgs e)
        {
            int index = patientComboBox.SelectedIndex;
            var id = searchedId[index];
            main.Content = new editPatient(id);
        }
    }
}

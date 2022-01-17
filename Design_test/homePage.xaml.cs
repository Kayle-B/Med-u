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
        MainWindow mWindow = (MainWindow)Application.Current.MainWindow;



        public homePage(System.Windows.Controls.Frame main, SQLServer sQLServer)
        {
            InitializeComponent();
            // set the received data in the variables above
            this.main = main;
            this.sQLServer = sQLServer;
            this.doctor = mWindow.doctor;
            patientCountLabel.Content = doctor.Patients.Count();
        }


        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            userNameLabel.Content = doctor.First_name;
        }

        private void patientComboBox_KeyUp(object sender, KeyEventArgs e)
        {
            // On every new letter in the searchbox clear the list so we don't get double data
            patientComboBox.Items.Clear();
            searchedId.Clear();

            //if the searchbox is empty, show all patients
            if (patientComboBox.Text != null)
            {
                doctor.loadPatients();

                //Check if the combo box is not empty
                if (patientComboBox.Text != "")
                {
                    //for each patient that the doctor has, check if the name contains any letters in the searchbox
                    foreach (var patient in doctor.Patients)
                    {
                        if (patient.firstname.ToLower().Contains(patientComboBox.Text.ToLower()))
                        {
                            searchedId.Add(patient.id);
                            patientComboBox.Items.Add(patient.firstname);
                        }
                    }
                    if (searchedId.Count != 0)
                    {
                        patientComboBox.IsDropDownOpen = true;
                    }
                    else
                    {
                        patientComboBox.IsDropDownOpen = false;
                    }

                }
            }
        }

        private void patientComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if there is a selected patient, show two buttons under the patient
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

        private void patientComboBox_DropDownOpened(object sender, EventArgs e)
        {
            if (patientComboBox.Text == "")
            {
                patientComboBox.Items.Clear();
                searchedId.Clear();
                foreach (var patient in doctor.Patients)
                {
                    searchedId.Add(patient.id);
                    patientComboBox.Items.Add(patient.firstname);
                }
                patientComboBox.IsDropDownOpen = true;
            }
        }

        private void medListBtn_Click(object sender, RoutedEventArgs e)
        {
            int index = patientComboBox.SelectedIndex;
            var id = searchedId[index];
            main.Content = new medicineListPage(id, main);
        }

        private void addPatientButton_Click(object sender, RoutedEventArgs e)
        {
            string name = addPatientTextbox.Text;
            main.Content = new addPatientPage(name, doctor);
        }

        private void detailBtn_Click(object sender, RoutedEventArgs e)
        {
            int index = patientComboBox.SelectedIndex;
            var id = searchedId[index];
            main.Content = new editPatientPage(id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Interaction logic for addIntakeMomentPage.xaml
    /// </summary>
    /// 
    public partial class addIntakeMomentPage : Page
    {
        System.Windows.Controls.Frame main;
        List<DateTime> dateTimes = new List<DateTime>();
        List<Medicine> medicines = new List<Medicine>();
        SQLServer sqlServer = new SQLServer();
        // I create a searchedId list here
        // We use this later on line 65
        List<int> searchedId = new List<int>();
        List<consumption_date> consumption_Dates = new List<consumption_date>();
        int amount;


        int medicine_id;
        int patient_id;

        int index;

        public addIntakeMomentPage(System.Windows.Controls.Frame main, int patient_id)
        {
            InitializeComponent();
            this.main = main;
            this.patient_id = patient_id;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            // if the page gets loaded clear any previously set data
            medicines.Clear();
            string query = "SELECT * FROM medicine";
            var reader = sqlServer.executeQeury(query);
            while (reader.Read())
            {
                medicines.Add(new Medicine(reader.GetInt32("id"), reader.GetString("name"), reader.GetString("consumption_method"), reader.GetString("category"), reader.GetString("prescription")));
            }

            foreach (var medicine in medicines)
            {
                // for each medicine we add that name to the item box
                medicineComboBox.Items.Add(medicine.name);
                // than we add their id to a seperate list
                // because we add both values in the list their index shall be the same
                // that why at line 103 we can set the medicine id to the value at the same index as the combobox
                searchedId.Add(medicine.id);
            }
        }

        private void addMomentBtn_Click(object sender, RoutedEventArgs e)
        {
            //try to parse the input to a number, catch if it's not a number
            try
            {
                amount = int.Parse(amountTextBox.Text);
            }
            catch { }
            if (dateTimeInput.Value.HasValue == false || medicineComboBox.SelectedIndex == -1 || amount <= 0)
            {
                MessageBox.Show("Alle velden moeten worden ingevuld!");
                return;
            }
            string stringDate = dateTimeInput.Text;
            var dateTime = DateTime.Parse(stringDate);
            dateTimes.Add(dateTime);

            tempMomentListbox.Items.Add(string.Format("Date: {0} | Pill: {1} | Aantal: {2}", stringDate, medicineComboBox.SelectedValue, amountTextBox.Text));
            int medicine_id = medicineComboBox.SelectedIndex + 1;

            
            consumption_Dates.Add(new consumption_date(medicine_id, dateTime, patient_id, amount));

            // after a new consumption data is created, clear all the input fields
            clearInputs();
        }

        private void clearInputs()
        {
            dateTimeInput.Value = null;
            medicineComboBox.SelectedItem = null;
            amountTextBox.Text = null;

        }
        private void removeMomentBtn_Click(object sender, RoutedEventArgs e)
        {
            medicine_id = searchedId[index];
            var selected = tempMomentListbox.SelectedItem;
            tempMomentListbox.Items.Remove(selected);
            consumption_Dates.RemoveAt(index);
        }



        private void saveMomentBtn_Click(object sender, RoutedEventArgs e)
        {
            // STILL NEED TO CHANGE DATE FORMAT
            foreach (var singleDate in consumption_Dates)
            {
                string query = string.Format("INSERT INTO consumption_date (`date`, `amount`, `medicine_id`, `patient_id`) VALUES ('{0}','{1}','{2}','{3}')", singleDate.date.ToString("yyyy/MM/dd HH:mm:ss"), singleDate.amount, singleDate.medicine_id, patient_id);
                sqlServer.executeQeury(query);
            }
            tempMomentListbox.Items.Clear();
            clearInputs();
        }
    }
}

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
    /// Interaction logic for addIntakeMomentPage.xaml
    /// </summary>
    /// 
    public partial class addIntakeMomentPage : Page
    {
        System.Windows.Controls.Frame main;
        List<DateTime> dateTimes = new List<DateTime>();
        List<Medicine> medicines = new List<Medicine>();
        SQLServer sqlServer = new SQLServer();
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
            medicines.Clear();
            string query = "SELECT * FROM medicine";
            var reader = sqlServer.executeQeury(query);
            while (reader.Read())
            {
                medicines.Add(new Medicine(reader.GetInt32("id"), reader.GetString("name"), reader.GetString("consumption_method"), reader.GetString("category"), reader.GetString("prescription")));
            }

            foreach (var medicine in medicines)
            {
                medicineComboBox.Items.Add(medicine.name);
                searchedId.Add(medicine.id);
            }
        }

        private void addMomentBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                amount = int.Parse(amountTextBox.Text);
            }
            catch { }
            if (dateTimeInput.Value.HasValue == false || medicineComboBox.SelectedIndex == null || amount <= 0)
            {
                MessageBox.Show("Alle velden moeten worden ingevuld!");
                return;
            }
            dateTimes.Add((DateTime)dateTimeInput.Value);

            tempMomentListbox.Items.Add(string.Format("Date: {0} | Pill: {1} | Aantal: {2}", (DateTime)dateTimeInput.Value, medicineComboBox.SelectedValue, amountTextBox.Text));
            int medicine_id = medicineComboBox.SelectedIndex + 1;


            consumption_Dates.Add(new consumption_date(medicine_id, DateTime.Today, patient_id, amount));

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
                string query = string.Format("INSERT INTO consumption_date (`date`, `amount`, `medicine_id`, `patient_id`) VALUES ('{0}','{1}','{2}','{3}')", singleDate.date, singleDate.amount, singleDate.medicine_id, patient_id);
                sqlServer.executeQeury(query);
            }
            tempMomentListbox.Items.Clear();
            clearInputs();
        }
    }
}

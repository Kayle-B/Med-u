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
    /// Interaction logic for medicineListPage.xaml
    /// </summary>
    public partial class medicineListPage : Page
    {
        int patient_id;
        SQLServer sQLServer;
        Patient patient;


        public medicineListPage(int patient_id)
        {
            InitializeComponent();
            this.patient_id = patient_id;
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            patient = new Patient();
            patient.getMedicine(patient_id);
            foreach (Medicine medicine in patient.medicines)
            {
                string data = string.Format("Naam: {0} | Consumptie: {1} | Categorie: {2} | Bijsluiter: {3}", medicine.name, medicine.consumption_method, medicine.category, medicine.prescription );
                medicineListBox.Items.Add(data);
            }
        }
    }
}

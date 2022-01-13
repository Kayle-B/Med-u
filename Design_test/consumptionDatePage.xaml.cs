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
    /// Interaction logic for consumptionDatePage.xaml
    /// </summary>
    public partial class consumptionDatePage : Page
    {
        System.Windows.Controls.Frame main;
        Patient patient;
        int patient_id;
        consumption_date consumption_date;
        public consumptionDatePage(System.Windows.Controls.Frame main, int patient_id)
        {
            InitializeComponent();
            this.main = main;
            this.patient_id = patient_id;
        }

        private void consumptionDateDataGrid_Loaded(object sender, RoutedEventArgs e)
        {
/*            consumption_date = new consumption_date(patient_id);
            consumptionDateDataGrid.ItemsSource = consumption_date;*/
        }

        private void consumptionDateDataGrid_Loaded_1(object sender, RoutedEventArgs e)
        {
            //tried to set patient_id and call it in the class with this.id but always returns 0
            patient = new Patient(patient_id);
            patient.getConsumption_dates(patient_id);

            consumptionDateDataGrid.ItemsSource = patient.consumption_date;
        }
    }
}

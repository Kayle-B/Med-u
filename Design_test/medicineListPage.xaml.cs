using System;
using System.Collections.Generic;
using System.Data;
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
    /// 
    ///
    /// Added a remove funtion (Check id of medicine and remove all consumption dates with that medicine's id
    /// Added a add function that lets you select a medicine and a time when and an amount
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
            medicineDataGrid.ItemsSource = patient.medicines;
        }
    }
}

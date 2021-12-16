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
using System.Data.SqlClient;

namespace Design_test
{
    /// <summary>
    /// Interaction logic for homePage.xaml
    /// </summary>
    public partial class homePage : Page
    {
        string connString1 = "data source=127.0.0.1; port=3306; user id=root;password=;database=pt2;";
        string connString = "Server=127.0.0.1;Database=pt2;User Id=root;Password=;";

        

        public string query = "SELECT * FROM patient";

        public homePage()
        {
            InitializeComponent();
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.CommandTimeout = 60;
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    Console.WriteLine(reader.GetString(0));
                }
                else
                {
                    MessageBox.Show("There we no rows found");
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                //MessagBox.Show(ex);
            }
        }

        private void addPatientButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(patientTextBox.Text != null)
            {

            }
        }
    }
}

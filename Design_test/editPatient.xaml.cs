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
    /// Interaction logic for editPatient.xaml
    /// </summary>
    public partial class editPatient : Page
    {
        string name;
        string[] split;
        public editPatient(string name)
        {
            InitializeComponent();
            this.name = name;
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
    }
}

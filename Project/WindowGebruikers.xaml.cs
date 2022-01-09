using Project_DAL;
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
using System.Windows.Shapes;

namespace Project
{
    /// <summary>
    /// Interaction logic for WindowGebruikers.xaml
    /// </summary>
    public partial class WindowGebruikers : Window
    {
        public WindowGebruikers()
        {
            InitializeComponent();
        }

        private void btnZoekOpEmail_Click(object sender, RoutedEventArgs e)
        {
            datagridGebruiker.ItemsSource = DatabaseOperations.OphaleGebruikerViaEmail(txtZoekOpEmail.Text);
        }

        private void btnVoegGebruikerToe_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

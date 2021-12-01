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
    /// Interaction logic for WindowAlleDB.xaml
    /// </summary>
    public partial class WindowAlleDB : Window
    {
        public WindowAlleDB()
        {
            InitializeComponent();
        }

        private void btnDataVerenigingen_Click(object sender, RoutedEventArgs e)
        {
            datagridVerenigingen.ItemsSource = DatabaseOperations.OphalenVereniging();
        }

        private void btnDataEvenementen_Click(object sender, RoutedEventArgs e)
        {
            datagridVerenigingen.ItemsSource = DatabaseOperations.OphalenEvenementen();
        }

        private void btnDataGebruikers_Click(object sender, RoutedEventArgs e)
        {
            datagridVerenigingen.ItemsSource = DatabaseOperations.OphalenGebruikers();
        }

        private void btnDataCategorieën_Click(object sender, RoutedEventArgs e)
        {
            datagridVerenigingen.ItemsSource = DatabaseOperations.OphalenCategorie();
        }

        private void btnDataZoekVerenigingen_Click(object sender, RoutedEventArgs e)
        {
            WindowVerenigingen wv = new WindowVerenigingen();
            wv.ShowDialog();
        }

        private void btnDataZoekEvenementen_Click(object sender, RoutedEventArgs e)
        {
            WindowEvenementen we = new WindowEvenementen();
            we.ShowDialog();
        }

        private void btnDataZoekGebruikers_Click(object sender, RoutedEventArgs e)
        {
            WindowGebruikers wg = new WindowGebruikers();
            wg.ShowDialog();
        }
    }
}

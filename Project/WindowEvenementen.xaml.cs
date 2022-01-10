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
    /// Interaction logic for WindowEvenementen.xaml
    /// </summary>
    public partial class WindowEvenementen : Window
    {
        public WindowEvenementen()
        {
            InitializeComponent();
        }

        private void btnZoekOpTitel_Click(object sender, RoutedEventArgs e)
        {
            datagridEvenementen.ItemsSource = DatabaseOperations.OphaleEventsViaTitels(txtZoekOpTitel.Text);
        }

        private void btnZoekOpPrijs_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (int.TryParse(txtZoekOpPrijs.Text, out int prijs))
                {
                    Event verenigingsevent = DatabaseOperations.OphalenEventViaPrijs(prijs);

                    if (verenigingsevent == null)
                    {
                        MessageBox.Show("Event niet gevonden");
                    }
                    else
                    {
                        MessageBox.Show(verenigingsevent.titel + " " +  verenigingsevent.prijs);
                    }
                }
                else
                {
                    MessageBox.Show("Prijs moet nummeriek zijn!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("oei, query niet goed opgesteld" + ex.Message);
            }
        }

        private void btnZoekOpPostcode_Click(object sender, RoutedEventArgs e)
        {
            datagridEvenementen.ItemsSource = DatabaseOperations.OphalenEventViaPostcode(txtZoekOpPostcode.Text);
        }

        private void btnZoekOpStraat_Click(object sender, RoutedEventArgs e)
        {
            datagridEvenementen.ItemsSource = DatabaseOperations.OphalenEventViaStraat(txtZoekOpStraat.Text);
        }

        private void btnVoegEvenementToe_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

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
    /// Interaction logic for WindowVerenigingen.xaml
    /// </summary>
    public partial class WindowVerenigingen : Window
    {
        public WindowVerenigingen()
        {
            InitializeComponent();
        }

        private void btnZoekOpNaamVereniging_Click(object sender, RoutedEventArgs e)
        {
            datagridVerenigingen1.ItemsSource = DatabaseOperations.OphaleVerenigingViaNaam(txtZoekNaamVereniging.Text);
        }

        private void btnZoekOpGemeente_Click(object sender, RoutedEventArgs e)
        {
            datagridVerenigingen1.ItemsSource = DatabaseOperations.OphaleVerenigingViaGemeente(txtGemeente.Text);
        }

        private void btnZoekViaStraat_Click(object sender, RoutedEventArgs e)
        {
            datagridVerenigingen1.ItemsSource = DatabaseOperations.OphaleVerenigingViaStraat(txtStraat.Text);
        }

        private void btnZoekOpVerenigingId_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (int.TryParse(txtVerenigingId.Text, out int verenigingId))
                {
                    Vereniging vereniging = DatabaseOperations.OphaleVerenigingViaId(verenigingId);

                    if (vereniging == null)
                    {
                        MessageBox.Show("Vereniging niet gevonden");
                    }
                    else
                    {
                        MessageBox.Show(vereniging.naam);
                    }
                }
                else
                {
                    MessageBox.Show("verenigingId moet nummeriek zijn!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("oei, query niet goed opgesteld" + ex.Message);
            }
        }

        private void btnVoegVerenigingToe_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

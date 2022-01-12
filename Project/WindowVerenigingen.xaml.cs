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
                    List<Vereniging> vereniging = DatabaseOperations.OphaleVerenigingViaId(verenigingId);
                    datagridVerenigingen1.ItemsSource = vereniging;
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

        private string Valideer(string columnName)
        {
            if (columnName == "txtVerenigingNaam" && string.IsNullOrWhiteSpace(txtVerenigingNaam.Text))
            {
                return "Verenigings naam is een verplicht in te vullen veld!" + Environment.NewLine;
            }
            if (columnName == "txtVerenigingBeschrijving" && string.IsNullOrWhiteSpace(txtVerenigingBeschrijving.Text))
            {
                return "Beschrijving is een verplicht in te vullen veld!" + Environment.NewLine;
            }
            if (columnName == "txtVerenigingStraat" && string.IsNullOrWhiteSpace(txtVerenigingStraat.Text))
            {
                return "Straat is een verplicht in te vullen veld!" + Environment.NewLine;
            }
            if (columnName == "txtVerenigingHuisnr" && string.IsNullOrWhiteSpace(txtVerenigingHuisnr.Text))
            {
                return "huisnummer is een verplicht in te vullen veld!" + Environment.NewLine;
            }
            if (columnName == "txtVerenigingGemeente" && string.IsNullOrWhiteSpace(txtVerenigingGemeente.Text))
            {
                return "Straat is een verplicht in te vullen veld!" + Environment.NewLine;
            }
            if (columnName == "txtVerenigingPostcode" && string.IsNullOrWhiteSpace(txtVerenigingPostcode.Text))
            {
                return "postcode is een verplicht in te vullen veld!" + Environment.NewLine;
            }
            return "";
        }

        private void btnVoegVerenigingToe_Click(object sender, RoutedEventArgs e)
        {
            string foutmelding = Valideer("txtVerenigingNaam");
            foutmelding += Valideer("txtVerenigingBeschrijving");
            foutmelding += Valideer("txtVerenigingStraat");
            foutmelding += Valideer("txtVerenigingHuisnr");
            foutmelding += Valideer("txtVerenigingGemeente");
            foutmelding += Valideer("txtVerenigingPostcode");

            if (string.IsNullOrWhiteSpace(foutmelding))
            {
                Vereniging vereniging = new Vereniging();
                vereniging.naam = txtVerenigingNaam.Text;
                vereniging.beschrijving = txtVerenigingBeschrijving.Text;
                vereniging.straat = txtVerenigingStraat.Text;
                vereniging.huisnr = txtVerenigingHuisnr.Text;
                vereniging.gemeente = txtVerenigingGemeente.Text;
                vereniging.postcode = txtVerenigingPostcode.Text;

            }
            else
            {
                MessageBox.Show(foutmelding);
            }
        }
    }
}

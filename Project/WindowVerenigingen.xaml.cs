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
            Resetten();
        }

        private void btnZoekOpGemeente_Click(object sender, RoutedEventArgs e)
        {
            datagridVerenigingen1.ItemsSource = DatabaseOperations.OphaleVerenigingViaGemeente(txtGemeente.Text);
            Resetten();
        }

        private void btnZoekViaStraat_Click(object sender, RoutedEventArgs e)
        {
            datagridVerenigingen1.ItemsSource = DatabaseOperations.OphaleVerenigingViaStraat(txtStraat.Text);
            Resetten();
        }

        private void btnZoekOpVerenigingId_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (int.TryParse(txtVerenigingId.Text, out int verenigingId))
                {
                    List<Vereniging> vereniging = DatabaseOperations.OphaleVerenigingViaId(verenigingId);
                    datagridVerenigingen1.ItemsSource = vereniging;
                    Resetten();
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
            if (columnName == "txtId" && !int.TryParse(txtId.Text, out int id))
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
            if (columnName == "datagridVerenigingen1" && datagridVerenigingen1.SelectedItem == null)
            {
                return "Selecteer een vereniging!" + Environment.NewLine;
            }
            return "";
        }

        private void btnVoegVerenigingToe_Click(object sender, RoutedEventArgs e)
        {
            string foutmelding = Valideer("txtVerenigingNaam");
            foutmelding += Valideer("txtVerenigingBeschrijving");
            foutmelding += Valideer("txtVerenigingStraat");
            foutmelding += Valideer("txtId");
            foutmelding += Valideer("txtVerenigingHuisnr");
            foutmelding += Valideer("txtVerenigingGemeente");
            foutmelding += Valideer("txtVerenigingPostcode");

            if (string.IsNullOrWhiteSpace(foutmelding))
            {
                Vereniging v = new Vereniging();
                v.naam = txtVerenigingNaam.Text;
                v.beschrijving = txtVerenigingBeschrijving.Text;
                v.straat = txtVerenigingStraat.Text;
                v.id = int.Parse(txtId.Text);
                v.huisnr = txtVerenigingHuisnr.Text;
                v.gemeente = txtVerenigingGemeente.Text;
                v.postcode = txtVerenigingPostcode.Text;

                if (v.IsGeldig())
                {
                    int ok = DatabaseOperations.ToevoegenVereniging(v);
                    if (ok <= 0)
                    {
                        MessageBox.Show("Toevoegen van vereniging is niet gelukt");
                    }
                    else
                    {
                        datagridVerenigingen1.ItemsSource = DatabaseOperations.OphaleVerenigingViaNaam(v.naam);
                    }
                }

                Resetten();
            }
            else
            {
                MessageBox.Show(foutmelding);
            }

        }

        private void btnVerwijderVereniging_Click(object sender, RoutedEventArgs e)
        {
            string foutmelding = Valideer("datagridVerenigingen1");

            if (string.IsNullOrWhiteSpace(foutmelding))
            {
                //verwijderen
                if (datagridVerenigingen1.SelectedItem is Vereniging v)
                {
                    //verwijderen uit database -> method toevoegen aan databaseOperations
                    int ok = DatabaseOperations.VerwijderVereniging(v);
                    if (ok <= 0)
                    {
                        MessageBox.Show("Verwijderen van vereniging is niet gelukt");
                    }
                    else
                    {
                        datagridVerenigingen1.ItemsSource = DatabaseOperations.OphaleVerenigingViaNaam(v.naam);
                        Resetten();
                    }
                }
            }
            else
            {
                MessageBox.Show(foutmelding);
            }
        }

        private void Resetten()
        {
            txtVerenigingNaam.Text = "";
            txtVerenigingBeschrijving.Text = "";
            txtVerenigingStraat.Text = "";
            txtId.Text = "";
            txtVerenigingHuisnr.Text = "";
            txtVerenigingGemeente.Text = "";
            txtVerenigingPostcode.Text = "";
            txtVerenigingId.Text = "";
            txtStraat.Text = "";
            txtGemeente.Text = "";
            txtZoekNaamVereniging.Text = "";
        }
    }
}

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
            Resetten();
        }

        private void btnZoekOpPrijs_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (int.TryParse(txtZoekOpPrijs.Text, out int Prijs))
                {
                    List<Event> ev = DatabaseOperations.OphalenEventViaPrijs(Prijs);
                    datagridEvenementen.ItemsSource = ev;
                    Resetten();
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
            Resetten();
        }

        private void btnZoekOpStraat_Click(object sender, RoutedEventArgs e)
        {
            datagridEvenementen.ItemsSource = DatabaseOperations.OphalenEventViaStraat(txtZoekOpStraat.Text);
            Resetten();
        }

        private void btnVoegEvenementToe_Click(object sender, RoutedEventArgs e)
        {
            string foutmelding = Valideer("txtTitel");
            foutmelding += Valideer("txtStraat");
            foutmelding += Valideer("txtGemeente");
            foutmelding += Valideer("txtId");
            foutmelding += Valideer("txtBeschrijving");
            foutmelding += Valideer("txtPostcode");
            foutmelding += Valideer("txtHuisnummer");

            if (string.IsNullOrWhiteSpace(foutmelding))
            {
                Event ev = new Event();
                ev.titel = txtTitel.Text;
                ev.straat = txtStraat.Text;
                ev.gemeente = txtGemeente.Text;
                ev.id = int.Parse(txtId.Text);
                ev.beschrijving = txtBeschrijving.Text;
                ev.postcode = txtPostcode.Text;
                ev.huisnr = txtHuisnummer.Text;

                if (ev.IsGeldig())
                {
                    int ok = DatabaseOperations.ToevoegenEvent(ev);
                    if (ok <= 0)
                    {
                        MessageBox.Show("Toevoegen van een evenement is niet gelukt");
                    }
                    else
                    {
                        datagridEvenementen.ItemsSource = DatabaseOperations.OphaleEventsViaTitels(ev.titel);
                    }
                }

                Resetten();
            }
            else
            {
                MessageBox.Show(foutmelding);
            }
        }

        private void btnVerwijderEvenement_Click(object sender, RoutedEventArgs e)
        {
            string foutmelding = Valideer("datagridEvenementen");

            if (string.IsNullOrWhiteSpace(foutmelding))
            {
                //verwijderen
                if (datagridEvenementen.SelectedItem is Event ev)
                {
                    //verwijderen uit database -> method toevoegen aan databaseOperations
                    int ok = DatabaseOperations.VerwijderEvent(ev);
                    if (ok <= 0)
                    {
                        MessageBox.Show("Verwijderen van een evenement is niet gelukt");
                    }
                    else
                    {
                        datagridEvenementen.ItemsSource = DatabaseOperations.OphaleEventsViaTitels(ev.titel);
                        Resetten();
                    }
                }
            }
            else
            {
                MessageBox.Show(foutmelding);
            }
        }

        private string Valideer(string columnName)
        {
            if (columnName == "txtTitel" && string.IsNullOrWhiteSpace(txtTitel.Text))
            {
                return "Titel naam is een verplicht in te vullen veld!" + Environment.NewLine;
            }
            if (columnName == "txtStraat" && string.IsNullOrWhiteSpace(txtStraat.Text))
            {
                return "Straat is een verplicht in te vullen veld!" + Environment.NewLine;
            }
            if (columnName == "txtHuisnummer" && string.IsNullOrWhiteSpace(txtHuisnummer.Text))
            {
                return "Huisnummer is een verplicht in te vullen veld!" + Environment.NewLine;
            }
            if (columnName == "txtId" && !int.TryParse(txtId.Text, out int id))
            {
                return "Id is een verplicht in te vullen veld!" + Environment.NewLine;
            }
            if (columnName == "txtGemeente" && string.IsNullOrWhiteSpace(txtGemeente.Text))
            {
                return "Gemeente is een verplicht in te vullen veld!" + Environment.NewLine;
            }
            if (columnName == "txtbeschrijving" && string.IsNullOrWhiteSpace(txtBeschrijving.Text))
            {
                return "beschrijving is een verplicht in te vullen veld!" + Environment.NewLine;
            }
            if (columnName == "txtPostcode" && string.IsNullOrWhiteSpace(txtPostcode.Text))
            {
                return "Postcode is een verplicht in te vullen veld!" + Environment.NewLine;
            }
            if (columnName == "datagridEvenementen" && datagridEvenementen.SelectedItem == null)
            {
                return "Selecteer een Evenement!" + Environment.NewLine;
            }
            return "";
        }

        private void Resetten()
        {
            txtTitel.Text = "";
            txtStraat.Text = "";
            txtGemeente.Text = "";
            txtId.Text = "";
            txtBeschrijving.Text = "";
            txtPostcode.Text = "";
            txtHuisnummer.Text = "";
            txtZoekOpTitel.Text = "";
            txtZoekOpStraat.Text = "";
            txtZoekOpPostcode.Text = "";
            txtZoekOpPrijs.Text = "";
        }
    }
}

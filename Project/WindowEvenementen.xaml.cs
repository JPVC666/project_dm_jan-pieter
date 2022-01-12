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
            //string foutmelding = Valideer("txtTitel");
            //foutmelding += Valideer("txtStraat");
            //foutmelding += Valideer("txtHuisnummer");
            //foutmelding += Valideer("txtGemeente");
            //foutmelding += Valideer("txtPrijs");
            //foutmelding += Valideer("txtPostcode");

            //if (string.IsNullOrWhiteSpace(foutmelding))
            //{
            //    Event ev = new Event();
            //    ev.titel = txtTitel.Text;
            //    ev.straat = txtStraat.Text;
            //    ev.huisnr = txtHuisnummer.Text;
            //    ev.gemeente = txtGemeente.Text;
            //    ev.prijs = int.Parse(txtPrijs.Text);
            //    ev.postcode = txtPostcode.Text;

            //    if (ev.)
            //    {
            //        int ok = DatabaseOperations.ToevoegenWerknemer(employee);
            //        if (ok > 0)
            //        {
            //            datagridWerknemers.ItemsSource = DatabaseOperations.OphalenWerknemersViaUitgeverID(publisher.pub_id);
            //            Wissen();
            //        }
            //        else
            //        {
            //            MessageBox.Show("Werknemer is niet toegevoegd!");
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show(employee.Error);
            //    }

            //}
            //else
            //{
            //    MessageBox.Show(foutmelding);
            //}
        }

        //private string Valideer(string columnName)
        //{
        //    if (columnName == "txtTitel" && string.IsNullOrWhiteSpace(txtTitel.Text))
        //    {
        //        return "Verenigings naam is een verplicht in te vullen veld!" + Environment.NewLine;
        //    }
        //    if (columnName == "txtStraat" && string.IsNullOrWhiteSpace(txtStraat.Text))
        //    {
        //        return "Beschrijving is een verplicht in te vullen veld!" + Environment.NewLine;
        //    }
        //    if (columnName == "txtHuisnummer" && string.IsNullOrWhiteSpace(txtHuisnummer.Text))
        //    {
        //        return "Straat is een verplicht in te vullen veld!" + Environment.NewLine;
        //    }
        //    if (columnName == "txtGemeente" && string.IsNullOrWhiteSpace(txtGemeente.Text))
        //    {
        //        return "huisnummer is een verplicht in te vullen veld!" + Environment.NewLine;
        //    }
        //    if (columnName == "txtPrijs" && string.IsNullOrWhiteSpace(txtPrijs.Text))
        //    {
        //        return "Straat is een verplicht in te vullen veld!" + Environment.NewLine;
        //    }
        //    if (columnName == "txtPostcode" && string.IsNullOrWhiteSpace(txtPostcode.Text))
        //    {
        //        return "postcode is een verplicht in te vullen veld!" + Environment.NewLine;
        //    }
        //    return "";
        //}
    }
}

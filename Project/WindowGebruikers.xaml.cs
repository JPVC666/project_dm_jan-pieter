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
            Resetten();
        }

        private string Valideer(string columnName)
        {
            if (columnName == "txtEmail" && string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                return "Email is een verplicht in te vullen veld!" + Environment.NewLine;
            }
            if (columnName == "txtPaswoord" && string.IsNullOrWhiteSpace(txtPaswoord.Text))
            {
                return "Paswoord is een verplicht in te vullen veld!" + Environment.NewLine;
            }
            if (columnName == "txtId" && !int.TryParse(txtId.Text, out int id))
            {
                return "Id is een verplicht in te vullen veld!" + Environment.NewLine;
            }
            if (columnName == "datagridGebruiker" && datagridGebruiker.SelectedItem == null)
            {
                return "Selecteer een Gebruiker!" + Environment.NewLine;
            }
            return "";
        }

        private void btnVoegGebruikerToe_Click(object sender, RoutedEventArgs e)
        {
            string foutmelding = Valideer("txtEmail");
            foutmelding += Valideer("txtPaswoord");
            foutmelding += Valideer("txtId");

            if (string.IsNullOrWhiteSpace(foutmelding))
            {
                Gebruiker g = new Gebruiker();
                g.email = txtEmail.Text;
                g.paswoord = txtPaswoord.Text;
                g.id = int.Parse(txtId.Text);

                if (g.IsGeldig())
                {
                    int ok = DatabaseOperations.ToevoegenGebruiker(g);
                    if (ok <= 0)
                    {
                        MessageBox.Show("Toevoegen van een gebruiker is niet gelukt");
                    }
                    else
                    {
                        datagridGebruiker.ItemsSource = DatabaseOperations.OphaleGebruikerViaEmail(g.email);
                    }
                }

                Resetten();
            }
            else
            {
                MessageBox.Show(foutmelding);
            }
        }

        private void btnVerwijderGebruiker_Click(object sender, RoutedEventArgs e)
        {
            string foutmelding = Valideer("datagridGebruiker");

            if (string.IsNullOrWhiteSpace(foutmelding))
            {
                //verwijderen
                if (datagridGebruiker.SelectedItem is Gebruiker g)
                {
                    //verwijderen uit database -> method toevoegen aan databaseOperations
                    int ok = DatabaseOperations.VerwijderGebruiker(g);
                    if (ok <= 0)
                    {
                        MessageBox.Show("Verwijderen van een gebruiker is niet gelukt");
                    }
                    else
                    {
                        datagridGebruiker.ItemsSource = DatabaseOperations.OphaleGebruikerViaEmail(g.email);
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
            txtEmail.Text = "";
            txtPaswoord.Text = "";
            txtId.Text = "";
            txtZoekOpEmail.Text = "";            
        }
    }
}

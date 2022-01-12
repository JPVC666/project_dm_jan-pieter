using Project_Models1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_DAL
{
    public partial class Event : BasisKlasse
    {
        public override string this[string ColumnName]
        {
            get
            {
                if (ColumnName == "titel" && string.IsNullOrWhiteSpace(titel))
                {
                    return "Titel is een verplicht veld!";
                }
                if (ColumnName == "straat" && string.IsNullOrWhiteSpace(straat))
                {
                    return "Straat is een verplicht veld!";
                }
                if (ColumnName == "huisnr" && string.IsNullOrWhiteSpace(huisnr))
                {
                    return "Huisnummer is een verplicht veld!";
                }
                if (ColumnName == "gemeente" && string.IsNullOrWhiteSpace(gemeente))
                {
                    return "Gemeente is een verplicht veld!";
                }
                if (ColumnName == "prijs" && prijs < 0)
                {
                    return "Prijs moet groter of gelijk zijn dan 0!";
                }
                if (ColumnName == "postcode" && string.IsNullOrWhiteSpace(postcode))
                {
                    return "Postcode is een verplicht veld!";
                }
                return "";
            }
        }

        public override bool Equals(object obj)
        {
            return obj is Event @event &&
                   titel == @event.titel;
        }

        public override int GetHashCode()
        {
            return 1962562927 + EqualityComparer<string>.Default.GetHashCode(titel);
        }
    }
}

using Project_Models1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_DAL
{
    public partial class Vereniging : BasisKlasse
    {
        public override string this[string ColumnName]
        {
            get
            {
                if (ColumnName == "naam" && string.IsNullOrWhiteSpace(naam))
                {
                    return "Naam is een verplicht veld!";
                }
                if (ColumnName == "beschrijving" && string.IsNullOrWhiteSpace(beschrijving))
                {
                    return "Beschrijving is een verplicht veld!";
                }
                if (ColumnName == "straat" && string.IsNullOrWhiteSpace(straat))
                {
                    return "Straat is een verplicht veld!";
                }
                if (ColumnName == "id" && id < 0)
                {
                    return "Id moet groter dan 0 zijn!";
                }
                if (ColumnName == "huisnr" && string.IsNullOrWhiteSpace(huisnr))
                {
                    return "Huisnummer is een verplicht veld!";
                }
                if (ColumnName == "gemeente" && string.IsNullOrWhiteSpace(gemeente))
                {
                    return "Gemeente is een verplicht veld!";
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
            return obj is Vereniging vereniging &&
                   naam == vereniging.naam;
        }

        public override int GetHashCode()
        {
            return -1562492934 + EqualityComparer<string>.Default.GetHashCode(naam);
        }

    }
}

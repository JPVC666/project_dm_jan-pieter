using Project_Models1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_DAL
{
    public partial class Gebruiker : BasisKlasse
    {
        public override string this[string ColumnName]
        {
            get
            {
                if (ColumnName == "id" && id < 0)
                {
                    return "Id moet groter dan 0 zijn!";
                }
                if (ColumnName == "email" && string.IsNullOrWhiteSpace(email))
                {
                    return "E-mail is een verplicht veld!";
                }
                if (ColumnName == "paswoord" && string.IsNullOrWhiteSpace(paswoord))
                {
                    return "Paswoord is een verplicht veld!";
                }                
                return "";
            }
        }

        public override bool Equals(object obj)
        {
            return obj is Gebruiker gebruiker &&
                   email == gebruiker.email;
        }

        public override int GetHashCode()
        {
            return 848330207 + EqualityComparer<string>.Default.GetHashCode(email);
        }
    }
}

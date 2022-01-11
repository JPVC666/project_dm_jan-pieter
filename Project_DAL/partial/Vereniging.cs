using Project_Models1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_DAL.partial
{
    public partial class Vereniging : BasisKlasse
    {
        public override string this[string ColumnName]
        {
            get
            {
                if (columnName == "Naam" && string.IsNullOrWhiteSpace(Naam))
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
        }
    }
}

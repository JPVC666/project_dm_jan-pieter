using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_DAL
{
    public static class DatabaseOperations
    {
        #region ophalen
        public static List<Vereniging> OphalenVereniging()
        {
            using (Verenigingen1Entities entities = new Verenigingen1Entities())
            {
                var query = entities.Vereniging;
                return query.ToList();                                                              
            }
        }

        public static List<Event> OphalenEvenementen()
        {
            using (Verenigingen1Entities entities = new Verenigingen1Entities())
            {
                var query = entities.Event;
                return query.ToList();                                                              
            }
        }

        public static List<Gebruiker> OphalenGebruikers()
        {
            using (Verenigingen1Entities entities = new Verenigingen1Entities())
            {
                var query = entities.Gebruiker;
                return query.ToList();
            }
        }

        public static List<Categorie> OphalenCategorie()
        {
            using (Verenigingen1Entities entities = new Verenigingen1Entities())
            {
                var query = entities.Categorie;
                return query.ToList();
            }
        }
        #endregion

        #region event
        public static List<Event> OphaleEventsViaTitels(string naam)
        {
            using (Verenigingen1Entities entities = new Verenigingen1Entities())
            {
                return entities.Event
                    .Where(x => x.titel.Contains(naam))
                    .OrderBy(x => x.titel)
                    .ToList();
            }
        }

        public static List<Event> OphalenEventViaStraat(string straat)
        {
            using (Verenigingen1Entities entities = new Verenigingen1Entities())
            {
                return entities.Event
                    .Where(x => x.straat.Contains(straat))
                    .OrderBy(x => x.titel)
                    .ToList();
                    
            }
        }

        public static Event OphalenEventViaPrijs(int Prijs)
        {
            using (Verenigingen1Entities entities = new Verenigingen1Entities())
            {
                var query = entities.Event
                    .Where(x => x.prijs == Prijs);
                return query.FirstOrDefault();
            }
        }

        public static List<Event> OphalenEventViaPostcode(string Postcode)
        {
            using (Verenigingen1Entities entities = new Verenigingen1Entities())
            {
                return entities.Event
                    .Where(x => x.postcode.Contains(Postcode))
                    .OrderBy(x => x.postcode)
                    .ToList();
                /*var query = entities.Event
                    .Where(x => x.postcode == Postcode);
                return query.SingleOrDefault();*/
            }
        }
        #endregion

        #region Gebruiker
        public static List<Gebruiker> OphaleGebruikerViaEmail(string email)
        {
            using (Verenigingen1Entities entities = new Verenigingen1Entities())
            {
                return entities.Gebruiker
                    .Where(x => x.email.Contains(email))
                    .OrderBy(x => x.email)
                    .ToList();
            }
        }
        #endregion

        #region Verenigingen
        public static List<Vereniging> OphaleVerenigingViaNaam(string naam)
        {
            using (Verenigingen1Entities entities = new Verenigingen1Entities())
            {
                return entities.Vereniging
                    .Where(x => x.naam.Contains(naam))
                    .OrderBy(x => x.naam)
                    .ToList();
            }
        }

        public static List<Vereniging> OphaleVerenigingViaGemeente(string gemeente)
        {
            using (Verenigingen1Entities entities = new Verenigingen1Entities())
            {
                return entities.Vereniging
                    .Where(x => x.gemeente.Contains(gemeente))
                    .OrderBy(x => x.gemeente)
                    .ToList();
            }
        }

        public static List<Vereniging> OphaleVerenigingViaStraat(string straat)
        {
            using (Verenigingen1Entities entities = new Verenigingen1Entities())
            {
                return entities.Vereniging
                    .Where(x => x.straat.Contains(straat))
                    .OrderBy(x => x.straat)
                    .ToList();
            }
        }

        public static Vereniging OphaleVerenigingViaId(int verenigingId)
        {
            using (Verenigingen1Entities entities = new Verenigingen1Entities())
            {
                var query = entities.Vereniging
                    .Where(x => x.id == verenigingId)
                    .OrderBy(x => x.naam);
                    return query.SingleOrDefault();
            }
        }
        #endregion

        #region categorie


        #endregion

        #region foutloggen
        public static void FoutLoggen(Exception fout)
        {
            using (StreamWriter writer = new StreamWriter("foutenbestand.txt", true))
            {
                writer.WriteLine(DateTime.Now.ToString("HH:mm:ss tt"));
                writer.WriteLine(fout.GetType().Name);
                writer.WriteLine(fout.Message);
                writer.WriteLine(fout.StackTrace);
                writer.WriteLine(new String('-', 80));
                writer.WriteLine();
            }
        }
        #endregion
    }
}

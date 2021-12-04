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
        public static List<Vereniging> OphalenVereniging()
        {
            using (VerenigingenEntities2 entities = new VerenigingenEntities2())
            {
                var query = entities.Vereniging;
                return query.ToList();                                                              
            }
        }

        public static List<Event> OphalenEvenementen()
        {
            using (VerenigingenEntities2 entities = new VerenigingenEntities2())
            {
                var query = entities.Event;
                return query.ToList();                                                              
            }
        }

        public static List<Gebruiker> OphalenGebruikers()
        {
            using (VerenigingenEntities2 entities = new VerenigingenEntities2())
            {
                var query = entities.Gebruiker;
                return query.ToList();
            }
        }

        public static List<Categorie> OphalenCategorie()
        {
            using (VerenigingenEntities2 entities = new VerenigingenEntities2())
            {
                var query = entities.Categorie;
                return query.ToList();
            }
        }

        public static List<Event> OphaleEventsViaTitels(string naam)
        {
            using (VerenigingenEntities2 entities = new VerenigingenEntities2())
            {
                return entities.Event
                    .Where(x => x.titel.Contains(naam))
                    .OrderBy(x => x.titel)
                    .ToList();
            }
        }

        public static List<Event> OphalenEventViaDatum(DateTime Datum)
        {
            using (VerenigingenEntities2 entities = new VerenigingenEntities2())
            {
                return entities.Event
                    .Where(x => x.datum == Datum)
                    .OrderBy(x => x.titel)
                    .ToList();
            }
        }

        public static Event OphalenEventViaPrijs(int Prijs)
        {
            using (VerenigingenEntities2 entities = new VerenigingenEntities2())
            {
                var query = entities.Event
                    .Where(x => x.prijs == Prijs);
                return query.SingleOrDefault();
            }
        }

        public static Event OphalenEventViaPostcode(int Postcode)
        {
            using (VerenigingenEntities2 entities = new VerenigingenEntities2())
            {
                var query = entities.Event
                    .Where(x => x.prijs == Postcode);
                return query.SingleOrDefault();
            }
        }

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
    }
}

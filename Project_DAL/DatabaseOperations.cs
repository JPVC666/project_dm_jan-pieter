using System;
using System.Collections.Generic;
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
    }
}

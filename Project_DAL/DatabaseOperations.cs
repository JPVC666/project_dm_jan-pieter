using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_DAL
{
    public static class DatabaseOperations
    {
        #region DataBewerking
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

        #region Add/Delete

        #region Vereniging
        public static int ToevoegenVereniging(Vereniging v)
        {
            try
            {
                using (Verenigingen1Entities entities = new Verenigingen1Entities())
                {
                    entities.Vereniging.Add(v);
                    return entities.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                FileOperations.FoutLoggen(ex);
                return 0;
            }
        }

        public static int VerwijderVereniging(Vereniging v)
        {
            try
            {
                using (Verenigingen1Entities entities = new Verenigingen1Entities())
                {
                    entities.Entry(v).State = EntityState.Deleted;
                    return entities.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                FileOperations.FoutLoggen(ex);
                return 0;
            }
        }
        #endregion

        #region Event
        public static int ToevoegenEvent(Event feest)
        {
            try
            {
                using (Verenigingen1Entities entities = new Verenigingen1Entities())
                {
                    entities.Event.Add(feest);
                    return entities.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                FileOperations.FoutLoggen(ex);
                return 0;
            }
        }

        public static int VerwijderEvent(Event feest)
        {
            try
            {
                using (Verenigingen1Entities entities = new Verenigingen1Entities())
                {
                    entities.Entry(feest).State = EntityState.Deleted;
                    return entities.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                FileOperations.FoutLoggen(ex);
                return 0;
            }
        }
        #endregion

        #region Gebruiker
        public static int ToevoegenGebruiker(Gebruiker g)
        {
            try
            {
                using (Verenigingen1Entities entities = new Verenigingen1Entities())
                {
                    entities.Gebruiker.Add(g);
                    return entities.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                FileOperations.FoutLoggen(ex);
                return 0;
            }
        }

        public static int VerwijderGebruiker(Gebruiker g)
        {
            try
            {
                using (Verenigingen1Entities entities = new Verenigingen1Entities())
                {
                    entities.Entry(g).State = EntityState.Deleted;
                    return entities.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                FileOperations.FoutLoggen(ex);
                return 0;
            }
        }
        #endregion
        #endregion

        #region Event
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
                    .OrderBy(x => x.straat)
                    .ThenBy(x => x.titel)
                    .ToList();                    
            }
        }

        public static List<Event> OphalenEventViaPrijs(int Prijs)
        {
            using (Verenigingen1Entities entities = new Verenigingen1Entities())
            {
                var query = entities.Event
                    .Where(x => x.prijs == Prijs)
                    .OrderBy(x => x.prijs);
                return query.ToList();
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
                    .OrderBy(x => x.id)
                    .ToList();
            }
        }

        public static List<Vereniging> OphaleVerenigingViaId(int verenigingId)
        {
            using (Verenigingen1Entities entities = new Verenigingen1Entities())
            {
                var query = entities.Vereniging
                    .Where(x => x.id == verenigingId)
                    .OrderBy(x => x.id);
                    return query.ToList();
            }
        }
        #endregion

        #region categorie


        #endregion
       
    }
}
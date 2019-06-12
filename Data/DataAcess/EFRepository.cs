using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tirelires.DataAcess
{
    public class EFRepository<T> : IRepository<T> where T : class
    {
        EDM contexte = new EDM();

      
        public T Ajouter(T nouveau)
        {
            try
            {
                T retour = contexte.Set<T>().Add(nouveau);
                contexte.SaveChanges();
                return retour;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ICollection<T> Lister()
        {
            return contexte.Set<T>().ToList();
        }

        public T Modifier(T nouveau)
        {
            try
            {
                contexte.Entry<T>(nouveau).State =
                    System.Data.Entity.EntityState.Modified;
                contexte.SaveChanges();
                return nouveau;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public virtual void Supprimer(int id)
        {
            try
            {
                contexte.Set<T>().Remove(contexte.Set<T>().Find(id));
                contexte.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public T Trouver(int id)
        {
            try
            {
                return contexte.Set<T>().Find(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int TrouverParEmail(string email)
        {
            try
            {
                
                return contexte.Clients.Where(c=>c.Email==email).FirstOrDefault().Id;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
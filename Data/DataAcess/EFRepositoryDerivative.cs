using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tirelires.DataAcess
{
    public class EFRepositoryDerivative<T> : EFRepository<T> where T : class
    {
        EDM contexte = new EDM();
        public override void Supprimer(int id)
        {
            
            try
            {
                
                var nouveau = contexte.Set<T>().Find(id);
                
                contexte.Entry<T>(nouveau).Property("IsActived").CurrentValue = false;
                contexte.Entry<T>(nouveau).Property("IsActived").IsModified = true;
                
                contexte.SaveChanges();
                
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tirelires.DataAcess;

namespace Tirelires.Controllers
{
    public class CommandeController : Controller
    {
        IRepository<Commande> rep = new EFRepository<Commande>();
        // GET: Commande
        public ActionResult Index()
        {
            IEnumerable<Commande> c = rep.Lister();
            return View(c);
        }

        // GET: Commande/Details/5
        public ActionResult Details(int id)
        {
            Commande c = rep.Trouver(id);
            PeuplerClientsViewData();
            return View(c);
        }

        private void PeuplerClientsViewData()
        {
            ViewData["IdClient"] = new SelectList((new EFRepository<Client>()).Lister()
                , "Id", "Nom"
                );
        }

        // GET: Commande/Create
        public ActionResult Create()
        {
            PeuplerClientsViewData();
            return View();
        }

        // POST: Commande/Create
        [HttpPost]
        public ActionResult Create(Commande c)
        {
            try
            {
                // TODO: Add insert logic here
                c.DateCommande = DateTime.Now;
                rep.Ajouter(c);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Commande/Edit/5
        public ActionResult Edit(int id)
        {
            Commande c = rep.Trouver(id);
            PeuplerClientsViewData();
            return View(c);
        }

        // POST: Commande/Edit/5
        [HttpPost]
        public ActionResult Edit(Commande c)
        {
            try
            {
                // TODO: Add update logic here
                rep.Modifier(c);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Commande/Delete/5
        public ActionResult Delete(int id)
        {
            PeuplerClientsViewData();
            return View();
        }

        // POST: Commande/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                // TODO: Add delete logic here
                rep.Supprimer(id);
                return RedirectToAction("Index");
            }
            catch
            {
                PeuplerClientsViewData();
                return View();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tirelires.DataAcess;

namespace Tirelires.Controllers
{
    public class AvisController : Controller
    {
        IRepository<Avi> rep = new EFRepository<Avi>();
        // GET: Avis
        public ActionResult Index()
        {
            IEnumerable<Avi> avis = rep.Lister();
            return View(avis);
        }

        // GET: Avis/Details/5
        public ActionResult Details(int id)
        {
            Avi a = rep.Trouver(id);
            PeuplerProduitsViewData();
            PeuplerClientsViewData();
            return View(a);
        }

        private void PeuplerProduitsViewData()
        {
            ViewData["IdProduit"] = new SelectList((new EFRepository<Produit>()).Lister()
                , "Id", "Nom"
                );
        }
        private void PeuplerClientsViewData()
        {
            ViewData["IdClient"] = new SelectList((new EFRepository<Client>()).Lister()
                , "Id", "Nom"
                );
        }

        // GET: Avis/Create
        public ActionResult Create()
        {
            PeuplerProduitsViewData();
            PeuplerClientsViewData();
            return View();
        }

        // POST: Avis/Create
        [HttpPost]
        public ActionResult Create(Avi a, FormCollection form)
        {
            try
            {
                // TODO: Add insert logic here
                a.Date = DateTime.Now;
                a.IsPublished = true;
                a.Note= int.Parse(form["myList"]);
                rep.Ajouter(a);
                return RedirectToAction("Index");
            }
            catch
            {
                PeuplerProduitsViewData();
                PeuplerClientsViewData();
                return View();
            }
        }

        // GET: Avis/Edit/5
        public ActionResult Edit(int id)
        {
            Avi a = rep.Trouver(id);
            PeuplerProduitsViewData();
            PeuplerClientsViewData();
            return View(a);
        }

        // POST: Avis/Edit/5
        [HttpPost]
        public ActionResult Edit(Avi a, FormCollection form)
        {
            try
            {
                // TODO: Add update logic here
                a.Date = DateTime.Now;
                a.IsPublished = true;
                a.Note = int.Parse(form["myListEdit"]);
                rep.Modifier(a);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Avis/Delete/5
        public ActionResult Delete(int id)
        {
            Avi a = rep.Trouver(id);
            PeuplerProduitsViewData();
            PeuplerClientsViewData();
            return View(a);
        }

        // POST: Avis/Delete/5
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
                return View();
            }
        }
    }
}

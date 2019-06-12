using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tirelires.DataAcess;

namespace Tirelires.Controllers
{
    public class FournisseurController : Controller
    {
        IRepository<Fournisseur> rep = new EFRepositoryDerivative<Fournisseur>();
        // GET: Fournisseur
        public ActionResult Index()
        {
            IEnumerable<Fournisseur> fournisseurs = rep.Lister();
            return View(fournisseurs);
        }

        // GET: Fournisseur/Details/5
        public ActionResult Details(int id)
        {
            Fournisseur f = rep.Trouver(id);
            return View(f);
        }

        // GET: Fournisseur/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Fournisseur/Create
        [HttpPost]
        public ActionResult Create(Fournisseur f)
        {
            try
            {
                // TODO: Add insert logic here
                rep.Ajouter(f);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Fournisseur/Edit/5
        public ActionResult Edit(int id)
        {
            Fournisseur f = rep.Trouver(id);
            return View(f);
        }

        // POST: Fournisseur/Edit/5
        [HttpPost]
        public ActionResult Edit(Fournisseur f)
        {
            try
            {
                // TODO: Add update logic here
                rep.Modifier(f);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Fournisseur/Delete/5
        public ActionResult Delete(int id)
        {
            Fournisseur f = rep.Trouver(id);
            return View(f);
        }

        // POST: Fournisseur/Delete/5
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

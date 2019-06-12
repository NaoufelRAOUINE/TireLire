using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tirelires.DataAcess;

namespace Tirelires.Controllers
{
    public class DetailsCommandeController : Controller
    {
        IRepository<DetailsCommande> rep = new EFRepository<DetailsCommande>();
        // GET: DetailsCommande
        public ActionResult Index()
        {
            IEnumerable<DetailsCommande> d = rep.Lister();
            return View(d);
        }

        // GET: DetailsCommande/Details/5
        public ActionResult Details(int id)
        {
            DetailsCommande d = rep.Trouver(id);
            PeuplerProduitsViewData();
            return View(d);
        }
        private void PeuplerProduitsViewData()
        {
            
            ViewData["IdProduit"] = new SelectList((new EFRepository<Produit>()).Lister()
               , "Id", "Nom"
               );
        }
        // GET: DetailsCommande/Create
        public ActionResult Create()
        {
            PeuplerProduitsViewData();
            return View();
        }

        // POST: DetailsCommande/Create
        [HttpPost]
        public ActionResult Create(DetailsCommande d)
        {
            try
            {
                // TODO: Add insert logic here
                rep.Ajouter(d);
                return RedirectToAction("Index");
            }
            catch
            {
                PeuplerProduitsViewData();
                return View();
            }
        }

        // GET: DetailsCommande/Edit/5
        public ActionResult Edit(int id)
        {
            DetailsCommande d = rep.Trouver(id);
            PeuplerProduitsViewData();
            return View(d);
        }

        // POST: DetailsCommande/Edit/5
        [HttpPost]
        public ActionResult Edit(DetailsCommande d)
        {
            try
            {
                // TODO: Add update logic here
                rep.Modifier(d);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: DetailsCommande/Delete/5
        public ActionResult Delete(int id)
        {
            PeuplerProduitsViewData();
            return View();
        }

        // POST: DetailsCommande/Delete/5
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

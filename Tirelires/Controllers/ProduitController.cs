using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tirelires.DataAcess;

namespace Tirelires.Controllers
{
    public class ProduitController : Controller
    {
        IRepository<Produit> rep = new EFRepositoryDerivative<Produit>();
        IRepository<Avi> repAvis = new EFRepository<Avi>();
        // GET: Produit
        public ActionResult Index()
        {
            IEnumerable<Produit> produits = rep.Lister();
            return View(produits);
        }

        // GET: Produit/Details/5
        public ActionResult Details(int id)
        {
            Produit p = rep.Trouver(id);
            PeuplerFournisseursViewData();
            return View(p);
        }

        // GET: Produit/Create
        public ActionResult Create()
        {
            PeuplerFournisseursViewData();
            return View();
        }
        private void PeuplerFournisseursViewData()
        {
            ViewData["IdFournisseur"] = new SelectList((new EFRepository<Fournisseur>()).Lister()
                , "Id", "Nom"
                );
        }
        // POST: Produit/Create
        [HttpPost,AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(Produit p, HttpPostedFileBase fichier)
        {
            try
            {
                // TODO: Add insert logic here
                if (fichier != null && fichier.ContentLength > 0)
                {
                    string _FileName = Path.GetFileName(fichier.FileName);
                    string _path = Path.Combine(Server.MapPath("~/Photos"), _FileName);
                    fichier.SaveAs(_path);
                    p.URLImage = "~/Photos/" + fichier.FileName;
                    rep.Ajouter(p);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                PeuplerFournisseursViewData();
                return View();
            }
        }

        // GET: Produit/Edit/5
        public ActionResult Edit(int id)
        {
            Produit p = rep.Trouver(id);
            PeuplerFournisseursViewData();
            return View(p);
        }

        // POST: Produit/Edit/5
        [HttpPost]
        public ActionResult Edit(Produit p, HttpPostedFileBase fichier)
        {
             
            try
            {
                
                // TODO: Add update logic here
                if (fichier != null && fichier.ContentLength>0)
                {
                    string _FileName = Path.GetFileName(fichier.FileName);
                    string _path = Path.Combine(Server.MapPath("~/Photos"), _FileName);
                    fichier.SaveAs(_path);
                    p.URLImage = "~/Photos/"+fichier.FileName;
                    rep.Modifier(p);
                }
                else
                {
                    ViewBag.message = "Please Select Image";
                }
                
                return RedirectToAction("Index");
            }
            catch
            {
                PeuplerFournisseursViewData();
                return View();
            }
        }

        // GET: Produit/Delete/5
        public ActionResult Delete(int id)
        {
            Produit p = rep.Trouver(id);
            PeuplerFournisseursViewData();
            return View(p);
        }

        // POST: Produit/Delete/5
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
                PeuplerFournisseursViewData();
                return View();
            }
        }
    }
}

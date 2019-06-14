using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tirelires.DataAcess;

namespace Tirelires.Controllers
{
    public class PanierController : Controller
    {
        IRepository<Produit> rep = new EFRepositoryDerivative<Produit>();

        Commande Panier;


        [Authorize]
        public ActionResult AjouterAuPanier(int id)
        {
            if (User.Identity.Name!="")
            {
                Session["IdUser"] = new EFRepository<Client>().TrouverParEmail(User.Identity.Name);
            }


            if (Session["panier"] == null )
            {
                Panier = new Commande() { DateCommande = DateTime.Now, IdClient = int.Parse(Session["IdUser"].ToString())};
                Panier.DetailsCommandes = new List<DetailsCommande>();
                Panier.DetailsCommandes.Add(new DetailsCommande {
                    IdProduit = id, Produit = rep.Trouver(id)
                    , Quantite = 1
                    , Commande=Panier
                });
                Session["panier"] = Panier;
            }
            else
            {
                Panier = (Commande)Session["panier"];
                if (Panier.DetailsCommandes.Where(d => d.IdProduit == id).Count() > 0)
                {
                    Panier.DetailsCommandes.Where(d => d.IdProduit == id).First().Quantite++;
                }
                else
                {
                    Panier.DetailsCommandes.Add(new DetailsCommande { IdProduit = id, Produit = rep.Trouver(id), Quantite = 1 });

                }
                Session["panier"] = Panier;
            }

            return RedirectToAction("Index");
        }

        public ActionResult CommanderPanier()
        {
            //Initialiser un Rep commande
            Commande Panier = (Commande)Session["panier"];
            IRepository<Commande> repCommande = new EFRepository<Commande>();
            foreach (DetailsCommande item in Panier.DetailsCommandes)
            {
                item.Prix = item.Produit.Prix * item.Quantite;
                item.Produit = null;
            }
            //ajouter panier dans les commandes
            repCommande.Ajouter(Panier);
            //panier a vider
            Session["panier"] = null;

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Incrementer(int IdProduit)
        {
            Panier = (Commande)Session["panier"];
            DetailsCommande detail = Panier.DetailsCommandes.Where(d => d.IdProduit == IdProduit).First();
            detail.Quantite++;
            Session["panier"] = Panier;
            //return View( detail);
            return RedirectToAction("Index", "Panier");
        }

        public ActionResult Decrementer(int IdProduit)
        {
            Panier = (Commande)Session["panier"];
            DetailsCommande detail = Panier.DetailsCommandes.Where(d => d.IdProduit == IdProduit).First();
            if(detail.Quantite>0)
            detail.Quantite--;
            Session["panier"] = Panier;
            //return View( detail);
            return RedirectToAction("Index", "Panier");
        }

        // GET: Panier
        public ActionResult Index()
        {
            if (Session["panier"] != null)
            {
                return View(((Commande)Session["panier"]));
            }
            else
            {
                return View(new Commande());
            }


        }

        // GET: Panier/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Panier/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Panier/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Panier/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Panier/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Panier/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Panier/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

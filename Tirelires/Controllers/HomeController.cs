using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tirelires.DataAcess;

namespace Tirelires.Controllers
{
    public class HomeController : Controller
    {
        IRepository<Produit> rep = new EFRepository<Produit>();
        public ActionResult Index()
        {
            IEnumerable<Produit> produits = rep.Lister();
            return View(produits);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
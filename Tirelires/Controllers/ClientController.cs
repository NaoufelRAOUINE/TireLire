using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tirelires.DataAcess;


namespace Tirelires.Controllers
{
    public class ClientController : Controller
    {
        IRepository<Client> rep = new EFRepositoryDerivative<Client>();
        // GET: Client
        public ActionResult Index()
        {
            IEnumerable<Client> clients = rep.Lister();
            return View(clients);
        }

        // GET: Client/Details/5
        public ActionResult Details(int id)
        {
            Client c = rep.Trouver(id);
            return View(c);
        }

        // GET: Client/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Client/Create
        [HttpPost]
        public ActionResult Create(Client c)
        {
            try
            {
                // TODO: Add insert logic here
                rep.Ajouter(c);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Client/Edit/5
        public ActionResult Edit(int id)
        {
            Client c = rep.Trouver(id);
            return View(c);
        }

        // POST: Client/Edit/5
        [HttpPost]
        public ActionResult Edit(Client c)
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

        // GET: Client/Delete/5
        public ActionResult Delete(int id)
        {
            Client c = rep.Trouver(id);
            return View(c);
            return View();
        }

        // POST: Client/Delete/5
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

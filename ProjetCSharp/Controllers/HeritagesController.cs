using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjetCSharp.Models;

namespace ProjetCSharp.Controllers
{
    public class HeritagesController : Controller
    {
        private BdHeritagesEntities db = new BdHeritagesEntities();

        // GET: Heritages
        public ActionResult Index()
        {
            var heritage = db.Heritage.Include(h => h.Ecole);
            return View(heritage.ToList());
        }

        // GET: Heritages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Heritage heritage = db.Heritage.Find(id);
            if (heritage == null)
            {
                return HttpNotFound();
            }
            return View(heritage);
        }

        // GET: Heritages/Create
        public ActionResult Create()
        {
            ViewBag.EcoleID = new SelectList(db.Ecole, "EcoleID", "Nom");
            return View();
        }

        // POST: Heritages/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HeritageID,Description,DateDece,DateHeritage,EcoleID,Montant")] Heritage heritage)
        {
            if (ModelState.IsValid)
            {
                db.Heritage.Add(heritage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EcoleID = new SelectList(db.Ecole, "EcoleID", "Nom", heritage.EcoleID);
            return View(heritage);
        }

        // GET: Heritages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Heritage heritage = db.Heritage.Find(id);
            if (heritage == null)
            {
                return HttpNotFound();
            }
            ViewBag.EcoleID = new SelectList(db.Ecole, "EcoleID", "Nom", heritage.EcoleID);
            return View(heritage);
        }

        // POST: Heritages/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HeritageID,Description,DateDece,DateHeritage,EcoleID,Montant")] Heritage heritage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(heritage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EcoleID = new SelectList(db.Ecole, "EcoleID", "Nom", heritage.EcoleID);
            return View(heritage);
        }

        // GET: Heritages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Heritage heritage = db.Heritage.Find(id);
            if (heritage == null)
            {
                return HttpNotFound();
            }
            return View(heritage);
        }

        // POST: Heritages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Heritage heritage = db.Heritage.Find(id);
            db.Heritage.Remove(heritage);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

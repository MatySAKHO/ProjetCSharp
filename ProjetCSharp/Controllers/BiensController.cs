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
    public class BiensController : Controller
    {
        private BdHeritagesEntities db = new BdHeritagesEntities();

        // GET: Biens
        public ActionResult Index()
        {
            var biens = db.Biens.Include(b => b.Heritage);
            return View(biens.ToList());
        }

        // GET: Biens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Biens biens = db.Biens.Find(id);
            if (biens == null)
            {
                return HttpNotFound();
            }
            return View(biens);
        }

        // GET: Biens/Create
        public ActionResult Create()
        {
            ViewBag.HeritageID = new SelectList(db.Heritage, "HeritageID", "Description");
            return View();
        }

        // POST: Biens/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BienID,Description,Montant,HeritageID")] Biens biens)
        {
            if (ModelState.IsValid)
            {
                db.Biens.Add(biens);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.HeritageID = new SelectList(db.Heritage, "HeritageID", "Description", biens.HeritageID);
            return View(biens);
        }

        // GET: Biens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Biens biens = db.Biens.Find(id);
            if (biens == null)
            {
                return HttpNotFound();
            }
            ViewBag.HeritageID = new SelectList(db.Heritage, "HeritageID", "Description", biens.HeritageID);
            return View(biens);
        }

        // POST: Biens/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BienID,Description,Montant,HeritageID")] Biens biens)
        {
            if (ModelState.IsValid)
            {
                db.Entry(biens).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HeritageID = new SelectList(db.Heritage, "HeritageID", "Description", biens.HeritageID);
            return View(biens);
        }

        // GET: Biens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Biens biens = db.Biens.Find(id);
            if (biens == null)
            {
                return HttpNotFound();
            }
            return View(biens);
        }

        // POST: Biens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Biens biens = db.Biens.Find(id);
            db.Biens.Remove(biens);
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

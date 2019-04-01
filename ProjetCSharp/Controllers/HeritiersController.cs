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
    public class HeritiersController : Controller
    {
        private BdHeritagesEntities db = new BdHeritagesEntities();

        [Authorize]
        // GET: Heritiers
        public ActionResult Index()
        {
            var heritier = db.Heritier.Include(h => h.Heritage);
            return View(heritier.ToList());
        }

        // GET: Heritiers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Heritier heritier = db.Heritier.Find(id);
            if (heritier == null)
            {
                return HttpNotFound();
            }
            return View(heritier);
        }

        // GET: Heritiers/Create
        public ActionResult Create()
        {
            ViewBag.HeritageID = new SelectList(db.Heritage, "HeritageID", "Description");
            return View();
        }

        // POST: Heritiers/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NomenclatureID,Sexe,Description,HeritageID")] Heritier heritier)
        {
            if (ModelState.IsValid)
            {
                db.Heritier.Add(heritier);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.HeritageID = new SelectList(db.Heritage, "HeritageID", "Description", heritier.HeritageID);
            return View(heritier);
        }

        // GET: Heritiers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Heritier heritier = db.Heritier.Find(id);
            if (heritier == null)
            {
                return HttpNotFound();
            }
            ViewBag.HeritageID = new SelectList(db.Heritage, "HeritageID", "Description", heritier.HeritageID);
            return View(heritier);
        }

        // POST: Heritiers/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NomenclatureID,Sexe,Description,HeritageID")] Heritier heritier)
        {
            if (ModelState.IsValid)
            {
                db.Entry(heritier).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HeritageID = new SelectList(db.Heritage, "HeritageID", "Description", heritier.HeritageID);
            return View(heritier);
        }

        // GET: Heritiers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Heritier heritier = db.Heritier.Find(id);
            if (heritier == null)
            {
                return HttpNotFound();
            }
            return View(heritier);
        }

        // POST: Heritiers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Heritier heritier = db.Heritier.Find(id);
            db.Heritier.Remove(heritier);
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

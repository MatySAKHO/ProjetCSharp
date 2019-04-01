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
    public class AyantDroitsController : Controller
    {
        private BdHeritagesEntities db = new BdHeritagesEntities();

        [Authorize]
        // GET: AyantDroits
        public ActionResult Index()
        {
            var ayantDroit = db.AyantDroit.Include(a => a.Heritier);
            return View(ayantDroit.ToList());
        }

        // GET: AyantDroits/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AyantDroit ayantDroit = db.AyantDroit.Find(id);
            if (ayantDroit == null)
            {
                return HttpNotFound();
            }
            return View(ayantDroit);
        }

        // GET: AyantDroits/Create
        public ActionResult Create()
        {
            ViewBag.NomenclatureID = new SelectList(db.Heritier, "NomenclatureID", "Sexe");
            return View();
        }

        // POST: AyantDroits/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ADrID,Prenom,Nom,Adresse,Age,Sexe,TypeHeritier,Description,NomenclatureID")] AyantDroit ayantDroit)
        {
            if (ModelState.IsValid)
            {
                db.AyantDroit.Add(ayantDroit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.NomenclatureID = new SelectList(db.Heritier, "NomenclatureID", "Sexe", ayantDroit.NomenclatureID);
            return View(ayantDroit);
        }

        // GET: AyantDroits/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AyantDroit ayantDroit = db.AyantDroit.Find(id);
            if (ayantDroit == null)
            {
                return HttpNotFound();
            }
            ViewBag.NomenclatureID = new SelectList(db.Heritier, "NomenclatureID", "Sexe", ayantDroit.NomenclatureID);
            return View(ayantDroit);
        }

        // POST: AyantDroits/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ADrID,Prenom,Nom,Adresse,Age,Sexe,TypeHeritier,Description,NomenclatureID")] AyantDroit ayantDroit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ayantDroit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.NomenclatureID = new SelectList(db.Heritier, "NomenclatureID", "Sexe", ayantDroit.NomenclatureID);
            return View(ayantDroit);
        }

        // GET: AyantDroits/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AyantDroit ayantDroit = db.AyantDroit.Find(id);
            if (ayantDroit == null)
            {
                return HttpNotFound();
            }
            return View(ayantDroit);
        }

        // POST: AyantDroits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AyantDroit ayantDroit = db.AyantDroit.Find(id);
            db.AyantDroit.Remove(ayantDroit);
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

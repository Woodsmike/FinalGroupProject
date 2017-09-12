using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ExerciseGO.Models;

namespace ExerciseGO.Controllers
{
    public class TargetAreasController : Controller
    {
        private ExerciseGOEntities db = new ExerciseGOEntities();

        // GET: TargetAreas
        public ActionResult Index()
        {
            return View(db.TargetAreas.ToList());
        }

        // GET: TargetAreas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TargetArea targetArea = db.TargetAreas.Find(id);
            if (targetArea == null)
            {
                return HttpNotFound();
            }
            return View(targetArea);
        }

        // GET: TargetAreas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TargetAreas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TargetAreaID,TargetAreaName")] TargetArea targetArea)
        {
            if (ModelState.IsValid)
            {
                db.TargetAreas.Add(targetArea);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(targetArea);
        }

        // GET: TargetAreas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TargetArea targetArea = db.TargetAreas.Find(id);
            if (targetArea == null)
            {
                return HttpNotFound();
            }
            return View(targetArea);
        }

        // POST: TargetAreas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TargetAreaID,TargetAreaName")] TargetArea targetArea)
        {
            if (ModelState.IsValid)
            {
                db.Entry(targetArea).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(targetArea);
        }

        // GET: TargetAreas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TargetArea targetArea = db.TargetAreas.Find(id);
            if (targetArea == null)
            {
                return HttpNotFound();
            }
            return View(targetArea);
        }

        // POST: TargetAreas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TargetArea targetArea = db.TargetAreas.Find(id);
            db.TargetAreas.Remove(targetArea);
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

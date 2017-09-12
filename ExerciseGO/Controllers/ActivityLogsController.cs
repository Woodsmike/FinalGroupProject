using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ExerciseGO.Models;
using Microsoft.AspNet.Identity;

namespace ExerciseGO.Controllers
{
    public class ActivityLogsController : Controller
    {
        private ExerciseGOEntities db = new ExerciseGOEntities();

        // GET: ActivityLogs
        public ActionResult Index()
        {
            var user = User.Identity.GetUserId();
            var activityLogs = db.ActivityLogs.Include(a => a.AspNetUser).Include(a => a.TargetArea);            
            var query = (from e in activityLogs
                         where e.AspNetUserID == user
                         select e);
            return View(query.ToList());
        }

        // GET: ActivityLogs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActivityLog activityLog = db.ActivityLogs.Find(id);
            if (activityLog == null)
            {
                return HttpNotFound();
            }
            return View(activityLog);
        }

        // GET: ActivityLogs/Create
        public ActionResult Create()
        {
            ViewBag.AspNetUserID = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.TargetAreaID = new SelectList(db.TargetAreas, "TargetAreaID", "TargetAreaName");
            return View();
        }

        // POST: ActivityLogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ActivityLogID,LogDate,TotalReps,TotalSets,Notes,AspNetUserID,TargetAreaID")] ActivityLog activityLog)
        {
            if (ModelState.IsValid)
            {
                var userID = User.Identity.GetUserId();
                activityLog.AspNetUserID = userID;
                activityLog.LogDate = DateTime.Now;
                db.ActivityLogs.Add(activityLog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AspNetUserID = new SelectList(db.AspNetUsers, "Id", "Email", activityLog.AspNetUserID);
            ViewBag.TargetAreaID = new SelectList(db.TargetAreas, "TargetAreaID", "TargetAreaName", activityLog.TargetAreaID);
            return View(activityLog);
        }

        // GET: ActivityLogs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActivityLog activityLog = db.ActivityLogs.Find(id);
            if (activityLog == null)
            {
                return HttpNotFound();
            }
            ViewBag.AspNetUserID = new SelectList(db.AspNetUsers, "Id", "Email", activityLog.AspNetUserID);
            ViewBag.TargetAreaID = new SelectList(db.TargetAreas, "TargetAreaID", "TargetAreaName", activityLog.TargetAreaID);
            return View(activityLog);
        }

        // POST: ActivityLogs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ActivityLogID,LogDate,TotalReps,TotalSets,Notes,AspNetUserID,TargetAreaID")] ActivityLog activityLog)
        {
            if (ModelState.IsValid)
            {
                db.Entry(activityLog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AspNetUserID = new SelectList(db.AspNetUsers, "Id", "Email", activityLog.AspNetUserID);
            ViewBag.TargetAreaID = new SelectList(db.TargetAreas, "TargetAreaID", "TargetAreaName", activityLog.TargetAreaID);
            return View(activityLog);
        }

        // GET: ActivityLogs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActivityLog activityLog = db.ActivityLogs.Find(id);
            if (activityLog == null)
            {
                return HttpNotFound();
            }
            return View(activityLog);
        }

        // POST: ActivityLogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ActivityLog activityLog = db.ActivityLogs.Find(id);
            db.ActivityLogs.Remove(activityLog);
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

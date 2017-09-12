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
    public class EmojisController : Controller
    {
        private ExerciseGOEntities db = new ExerciseGOEntities();

        // GET: Emojis
        public ActionResult Index()
        {
            return View(db.Emojis.ToList());
        }

        // GET: Emojis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emoji emoji = db.Emojis.Find(id);
            if (emoji == null)
            {
                return HttpNotFound();
            }
            return View(emoji);
        }

        // GET: Emojis/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Emojis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmojiID,EmojiName")] Emoji emoji)
        {
            if (ModelState.IsValid)
            {
                db.Emojis.Add(emoji);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(emoji);
        }

        // GET: Emojis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emoji emoji = db.Emojis.Find(id);
            if (emoji == null)
            {
                return HttpNotFound();
            }
            return View(emoji);
        }

        // POST: Emojis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmojiID,EmojiName")] Emoji emoji)
        {
            if (ModelState.IsValid)
            {
                db.Entry(emoji).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(emoji);
        }

        // GET: Emojis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emoji emoji = db.Emojis.Find(id);
            if (emoji == null)
            {
                return HttpNotFound();
            }
            return View(emoji);
        }

        // POST: Emojis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Emoji emoji = db.Emojis.Find(id);
            db.Emojis.Remove(emoji);
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

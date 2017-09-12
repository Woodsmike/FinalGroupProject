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
    public class GamesController : Controller
    {
        private ExerciseGOEntities db = new ExerciseGOEntities();

        // GET: Games
        public ActionResult Index()
        {
            var games = db.Games.Include(g => g.Stage).Include(g => g.AspNetUser).Include(g => g.Emoji);
            return View(games.ToList());
        }

        // GET: Games/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.Games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // GET: Games/Create
        public ActionResult Create()
        {
            ViewBag.LevelID = new SelectList(db.Stages, "LevelID", "LevelName");
            ViewBag.AspNetUserID = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.EmojiID = new SelectList(db.Emojis, "EmojiID", "EmojiName");
            return View();
        }

        // POST: Games/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GameID,Point,UserName,IsSocial,LevelID,AspNetUserID,EmojiID")] Game game)
        {
            if (ModelState.IsValid)
            {
                db.Games.Add(game);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LevelID = new SelectList(db.Stages, "LevelID", "LevelName", game.LevelID);
            ViewBag.AspNetUserID = new SelectList(db.AspNetUsers, "Id", "Email", game.AspNetUserID);
            ViewBag.EmojiID = new SelectList(db.Emojis, "EmojiID", "EmojiName", game.EmojiID);
            return View(game);
        }

        // GET: Games/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.Games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            ViewBag.LevelID = new SelectList(db.Stages, "LevelID", "LevelName", game.LevelID);
            ViewBag.AspNetUserID = new SelectList(db.AspNetUsers, "Id", "Email", game.AspNetUserID);
            ViewBag.EmojiID = new SelectList(db.Emojis, "EmojiID", "EmojiName", game.EmojiID);
            return View(game);
        }

        // POST: Games/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GameID,Point,UserName,IsSocial,LevelID,AspNetUserID,EmojiID")] Game game)
        {
            if (ModelState.IsValid)
            {
                db.Entry(game).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LevelID = new SelectList(db.Stages, "LevelID", "LevelName", game.LevelID);
            ViewBag.AspNetUserID = new SelectList(db.AspNetUsers, "Id", "Email", game.AspNetUserID);
            ViewBag.EmojiID = new SelectList(db.Emojis, "EmojiID", "EmojiName", game.EmojiID);
            return View(game);
        }

        // GET: Games/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.Games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // POST: Games/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Game game = db.Games.Find(id);
            db.Games.Remove(game);
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

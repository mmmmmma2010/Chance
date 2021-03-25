using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Give_Pro.Models;
using WebApplication1.Models;

namespace Give_Pro.Controllers
{
    public class LevelArmiesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: LevelArmies
        public ActionResult Index()
        {
            return View(db.LevelArmies.ToList());
        }

        // GET: LevelArmies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LevelArmy levelArmy = db.LevelArmies.Find(id);
            if (levelArmy == null)
            {
                return HttpNotFound();
            }
            return View(levelArmy);
        }

        // GET: LevelArmies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LevelArmies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,LevelArmyName")] LevelArmy levelArmy)
        {
            if (ModelState.IsValid)
            {
                db.LevelArmies.Add(levelArmy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(levelArmy);
        }

        // GET: LevelArmies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LevelArmy levelArmy = db.LevelArmies.Find(id);
            if (levelArmy == null)
            {
                return HttpNotFound();
            }
            return View(levelArmy);
        }

        // POST: LevelArmies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,LevelArmyName")] LevelArmy levelArmy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(levelArmy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(levelArmy);
        }

        // GET: LevelArmies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LevelArmy levelArmy = db.LevelArmies.Find(id);
            if (levelArmy == null)
            {
                return HttpNotFound();
            }
            return View(levelArmy);
        }

        // POST: LevelArmies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LevelArmy levelArmy = db.LevelArmies.Find(id);
            db.LevelArmies.Remove(levelArmy);
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

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
    public class LevelComputersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: LevelComputers
        public ActionResult Index()
        {
            return View(db.LevelComputers.ToList());
        }

        // GET: LevelComputers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LevelComputer levelComputer = db.LevelComputers.Find(id);
            if (levelComputer == null)
            {
                return HttpNotFound();
            }
            return View(levelComputer);
        }

        // GET: LevelComputers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LevelComputers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,LevelComputerName")] LevelComputer levelComputer)
        {
            if (ModelState.IsValid)
            {
                db.LevelComputers.Add(levelComputer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(levelComputer);
        }

        // GET: LevelComputers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LevelComputer levelComputer = db.LevelComputers.Find(id);
            if (levelComputer == null)
            {
                return HttpNotFound();
            }
            return View(levelComputer);
        }

        // POST: LevelComputers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,LevelComputerName")] LevelComputer levelComputer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(levelComputer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(levelComputer);
        }

        // GET: LevelComputers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LevelComputer levelComputer = db.LevelComputers.Find(id);
            if (levelComputer == null)
            {
                return HttpNotFound();
            }
            return View(levelComputer);
        }

        // POST: LevelComputers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LevelComputer levelComputer = db.LevelComputers.Find(id);
            db.LevelComputers.Remove(levelComputer);
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

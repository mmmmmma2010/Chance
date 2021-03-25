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
    public class LevelEnglishesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: LevelEnglishes
        public ActionResult Index()
        {
            return View(db.LevelEnglishes.ToList());
        }

        // GET: LevelEnglishes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LevelEnglish levelEnglish = db.LevelEnglishes.Find(id);
            if (levelEnglish == null)
            {
                return HttpNotFound();
            }
            return View(levelEnglish);
        }

        // GET: LevelEnglishes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LevelEnglishes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,LevelEnglishName")] LevelEnglish levelEnglish)
        {
            if (ModelState.IsValid)
            {
                db.LevelEnglishes.Add(levelEnglish);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(levelEnglish);
        }

        // GET: LevelEnglishes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LevelEnglish levelEnglish = db.LevelEnglishes.Find(id);
            if (levelEnglish == null)
            {
                return HttpNotFound();
            }
            return View(levelEnglish);
        }

        // POST: LevelEnglishes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,LevelEnglishName")] LevelEnglish levelEnglish)
        {
            if (ModelState.IsValid)
            {
                db.Entry(levelEnglish).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(levelEnglish);
        }

        // GET: LevelEnglishes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LevelEnglish levelEnglish = db.LevelEnglishes.Find(id);
            if (levelEnglish == null)
            {
                return HttpNotFound();
            }
            return View(levelEnglish);
        }

        // POST: LevelEnglishes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LevelEnglish levelEnglish = db.LevelEnglishes.Find(id);
            db.LevelEnglishes.Remove(levelEnglish);
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

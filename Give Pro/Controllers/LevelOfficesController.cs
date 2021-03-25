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
    public class LevelOfficesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: LevelOffices
        public ActionResult Index()
        {
            return View(db.LevelOffices.ToList());
        }

        // GET: LevelOffices/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LevelOffice levelOffice = db.LevelOffices.Find(id);
            if (levelOffice == null)
            {
                return HttpNotFound();
            }
            return View(levelOffice);
        }

        // GET: LevelOffices/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LevelOffices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,LevelOfficeName")] LevelOffice levelOffice)
        {
            if (ModelState.IsValid)
            {
                db.LevelOffices.Add(levelOffice);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(levelOffice);
        }

        // GET: LevelOffices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LevelOffice levelOffice = db.LevelOffices.Find(id);
            if (levelOffice == null)
            {
                return HttpNotFound();
            }
            return View(levelOffice);
        }

        // POST: LevelOffices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,LevelOfficeName")] LevelOffice levelOffice)
        {
            if (ModelState.IsValid)
            {
                db.Entry(levelOffice).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(levelOffice);
        }

        // GET: LevelOffices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LevelOffice levelOffice = db.LevelOffices.Find(id);
            if (levelOffice == null)
            {
                return HttpNotFound();
            }
            return View(levelOffice);
        }

        // POST: LevelOffices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LevelOffice levelOffice = db.LevelOffices.Find(id);
            db.LevelOffices.Remove(levelOffice);
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

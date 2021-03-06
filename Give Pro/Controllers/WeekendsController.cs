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
    public class WeekendsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Weekends
        public ActionResult Index()
        {
            return View(db.Weekends.ToList());
        }

        // GET: Weekends/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Weekend weekend = db.Weekends.Find(id);
            if (weekend == null)
            {
                return HttpNotFound();
            }
            return View(weekend);
        }

        // GET: Weekends/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Weekends/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,WeekendName")] Weekend weekend)
        {
            if (ModelState.IsValid)
            {
                db.Weekends.Add(weekend);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(weekend);
        }

        // GET: Weekends/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Weekend weekend = db.Weekends.Find(id);
            if (weekend == null)
            {
                return HttpNotFound();
            }
            return View(weekend);
        }

        // POST: Weekends/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,WeekendName")] Weekend weekend)
        {
            if (ModelState.IsValid)
            {
                db.Entry(weekend).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(weekend);
        }

        // GET: Weekends/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Weekend weekend = db.Weekends.Find(id);
            if (weekend == null)
            {
                return HttpNotFound();
            }
            return View(weekend);
        }

        // POST: Weekends/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Weekend weekend = db.Weekends.Find(id);
            db.Weekends.Remove(weekend);
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

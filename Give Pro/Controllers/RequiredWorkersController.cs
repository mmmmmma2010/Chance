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
    public class RequiredWorkersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: RequiredWorkers
        public ActionResult Index()
        {
            return View(db.RequiredWorkers.ToList());
        }

        // GET: RequiredWorkers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RequiredWorkers requiredWorkers = db.RequiredWorkers.Find(id);
            if (requiredWorkers == null)
            {
                return HttpNotFound();
            }
            return View(requiredWorkers);
        }

        // GET: RequiredWorkers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RequiredWorkers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RequiredWorkersName")] RequiredWorkers requiredWorkers)
        {
            if (ModelState.IsValid)
            {
                db.RequiredWorkers.Add(requiredWorkers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(requiredWorkers);
        }

        // GET: RequiredWorkers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RequiredWorkers requiredWorkers = db.RequiredWorkers.Find(id);
            if (requiredWorkers == null)
            {
                return HttpNotFound();
            }
            return View(requiredWorkers);
        }

        // POST: RequiredWorkers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RequiredWorkersName")] RequiredWorkers requiredWorkers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(requiredWorkers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(requiredWorkers);
        }

        // GET: RequiredWorkers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RequiredWorkers requiredWorkers = db.RequiredWorkers.Find(id);
            if (requiredWorkers == null)
            {
                return HttpNotFound();
            }
            return View(requiredWorkers);
        }

        // POST: RequiredWorkers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RequiredWorkers requiredWorkers = db.RequiredWorkers.Find(id);
            db.RequiredWorkers.Remove(requiredWorkers);
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

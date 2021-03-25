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
    public class TimesworksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Timesworks
        public ActionResult Index()
        {
            return View(db.Timesworks.ToList());
        }

        // GET: Timesworks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Timeswork timeswork = db.Timesworks.Find(id);
            if (timeswork == null)
            {
                return HttpNotFound();
            }
            return View(timeswork);
        }

        // GET: Timesworks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Timesworks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TimesworkName")] Timeswork timeswork)
        {
            if (ModelState.IsValid)
            {
                db.Timesworks.Add(timeswork);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(timeswork);
        }

        // GET: Timesworks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Timeswork timeswork = db.Timesworks.Find(id);
            if (timeswork == null)
            {
                return HttpNotFound();
            }
            return View(timeswork);
        }

        // POST: Timesworks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TimesworkName")] Timeswork timeswork)
        {
            if (ModelState.IsValid)
            {
                db.Entry(timeswork).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(timeswork);
        }

        // GET: Timesworks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Timeswork timeswork = db.Timesworks.Find(id);
            if (timeswork == null)
            {
                return HttpNotFound();
            }
            return View(timeswork);
        }

        // POST: Timesworks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Timeswork timeswork = db.Timesworks.Find(id);
            db.Timesworks.Remove(timeswork);
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

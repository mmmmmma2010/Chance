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
    public class DrivingLicensesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DrivingLicenses
        public ActionResult Index()
        {
            return View(db.DrivingLicenses.ToList());
        }

        // GET: DrivingLicenses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DrivingLicense drivingLicense = db.DrivingLicenses.Find(id);
            if (drivingLicense == null)
            {
                return HttpNotFound();
            }
            return View(drivingLicense);
        }

        // GET: DrivingLicenses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DrivingLicenses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DrivingLicenseName")] DrivingLicense drivingLicense)
        {
            if (ModelState.IsValid)
            {
                db.DrivingLicenses.Add(drivingLicense);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(drivingLicense);
        }

        // GET: DrivingLicenses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DrivingLicense drivingLicense = db.DrivingLicenses.Find(id);
            if (drivingLicense == null)
            {
                return HttpNotFound();
            }
            return View(drivingLicense);
        }

        // POST: DrivingLicenses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DrivingLicenseName")] DrivingLicense drivingLicense)
        {
            if (ModelState.IsValid)
            {
                db.Entry(drivingLicense).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(drivingLicense);
        }

        // GET: DrivingLicenses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DrivingLicense drivingLicense = db.DrivingLicenses.Find(id);
            if (drivingLicense == null)
            {
                return HttpNotFound();
            }
            return View(drivingLicense);
        }

        // POST: DrivingLicenses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DrivingLicense drivingLicense = db.DrivingLicenses.Find(id);
            db.DrivingLicenses.Remove(drivingLicense);
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

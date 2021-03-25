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
    public class CompanyActivitiesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CompanyActivities
        public ActionResult Index()
        {
            return View(db.CompanyActivities.ToList());
        }

        // GET: CompanyActivities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyActivity companyActivity = db.CompanyActivities.Find(id);
            if (companyActivity == null)
            {
                return HttpNotFound();
            }
            return View(companyActivity);
        }

        // GET: CompanyActivities/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CompanyActivities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CompanyActivityName")] CompanyActivity companyActivity)
        {
            if (ModelState.IsValid)
            {
                db.CompanyActivities.Add(companyActivity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(companyActivity);
        }

        // GET: CompanyActivities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyActivity companyActivity = db.CompanyActivities.Find(id);
            if (companyActivity == null)
            {
                return HttpNotFound();
            }
            return View(companyActivity);
        }

        // POST: CompanyActivities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CompanyActivityName")] CompanyActivity companyActivity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(companyActivity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(companyActivity);
        }

        // GET: CompanyActivities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyActivity companyActivity = db.CompanyActivities.Find(id);
            if (companyActivity == null)
            {
                return HttpNotFound();
            }
            return View(companyActivity);
        }

        // POST: CompanyActivities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CompanyActivity companyActivity = db.CompanyActivities.Find(id);
            db.CompanyActivities.Remove(companyActivity);
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

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
    public class YearsExperiencesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: YearsExperiences
        public ActionResult Index()
        {
            return View(db.YearsExperiences.ToList());
        }

        // GET: YearsExperiences/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YearsExperience yearsExperience = db.YearsExperiences.Find(id);
            if (yearsExperience == null)
            {
                return HttpNotFound();
            }
            return View(yearsExperience);
        }

        // GET: YearsExperiences/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: YearsExperiences/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,YearsExperienceName")] YearsExperience yearsExperience)
        {
            if (ModelState.IsValid)
            {
                db.YearsExperiences.Add(yearsExperience);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(yearsExperience);
        }

        // GET: YearsExperiences/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YearsExperience yearsExperience = db.YearsExperiences.Find(id);
            if (yearsExperience == null)
            {
                return HttpNotFound();
            }
            return View(yearsExperience);
        }

        // POST: YearsExperiences/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,YearsExperienceName")] YearsExperience yearsExperience)
        {
            if (ModelState.IsValid)
            {
                db.Entry(yearsExperience).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(yearsExperience);
        }

        // GET: YearsExperiences/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YearsExperience yearsExperience = db.YearsExperiences.Find(id);
            if (yearsExperience == null)
            {
                return HttpNotFound();
            }
            return View(yearsExperience);
        }

        // POST: YearsExperiences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            YearsExperience yearsExperience = db.YearsExperiences.Find(id);
            db.YearsExperiences.Remove(yearsExperience);
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

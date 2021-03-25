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
    public class MonthlySalariesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MonthlySalaries
        public ActionResult Index()
        {
            return View(db.MonthlySalaries.ToList());
        }

        // GET: MonthlySalaries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MonthlySalary monthlySalary = db.MonthlySalaries.Find(id);
            if (monthlySalary == null)
            {
                return HttpNotFound();
            }
            return View(monthlySalary);
        }

        // GET: MonthlySalaries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MonthlySalaries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,MonthlySalaryName")] MonthlySalary monthlySalary)
        {
            if (ModelState.IsValid)
            {
                db.MonthlySalaries.Add(monthlySalary);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(monthlySalary);
        }

        // GET: MonthlySalaries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MonthlySalary monthlySalary = db.MonthlySalaries.Find(id);
            if (monthlySalary == null)
            {
                return HttpNotFound();
            }
            return View(monthlySalary);
        }

        // POST: MonthlySalaries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MonthlySalaryName")] MonthlySalary monthlySalary)
        {
            if (ModelState.IsValid)
            {
                db.Entry(monthlySalary).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(monthlySalary);
        }

        // GET: MonthlySalaries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MonthlySalary monthlySalary = db.MonthlySalaries.Find(id);
            if (monthlySalary == null)
            {
                return HttpNotFound();
            }
            return View(monthlySalary);
        }

        // POST: MonthlySalaries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MonthlySalary monthlySalary = db.MonthlySalaries.Find(id);
            db.MonthlySalaries.Remove(monthlySalary);
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

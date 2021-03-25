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
    public class AdvantagesWorksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AdvantagesWorks
        public ActionResult Index()
        {
            return View(db.AdvantagesWorks.ToList());
        }

        // GET: AdvantagesWorks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdvantagesWork advantagesWork = db.AdvantagesWorks.Find(id);
            if (advantagesWork == null)
            {
                return HttpNotFound();
            }
            return View(advantagesWork);
        }

        // GET: AdvantagesWorks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdvantagesWorks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AdvantagesWorkName")] AdvantagesWork advantagesWork)
        {
            if (ModelState.IsValid)
            {
                db.AdvantagesWorks.Add(advantagesWork);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(advantagesWork);
        }

        // GET: AdvantagesWorks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdvantagesWork advantagesWork = db.AdvantagesWorks.Find(id);
            if (advantagesWork == null)
            {
                return HttpNotFound();
            }
            return View(advantagesWork);
        }

        // POST: AdvantagesWorks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AdvantagesWorkName")] AdvantagesWork advantagesWork)
        {
            if (ModelState.IsValid)
            {
                db.Entry(advantagesWork).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(advantagesWork);
        }

        // GET: AdvantagesWorks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdvantagesWork advantagesWork = db.AdvantagesWorks.Find(id);
            if (advantagesWork == null)
            {
                return HttpNotFound();
            }
            return View(advantagesWork);
        }

        // POST: AdvantagesWorks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AdvantagesWork advantagesWork = db.AdvantagesWorks.Find(id);
            db.AdvantagesWorks.Remove(advantagesWork);
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

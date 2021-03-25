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
using System.IO;
using Microsoft.AspNet.Identity;

namespace Give_Pro.Controllers
{
    [Authorize]
    public class JobsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Jobs
        public ActionResult Index()
        {
            ViewBag.CurrentUser = User.Identity.GetUserId();
            ApplicationUser userinfo = db.Users.Find(ViewBag.CurrentUser);
            ViewBag.userType = userinfo.UserType;
            var jobs = db.Jobs.Include(j => j.AdvantagesWork).Include(j => j.Age).Include(j => j.Always).Include(j => j.Category).Include(j => j.Cities).Include(j => j.CompanyActivity).Include(j => j.Countries).Include(j => j.DrivingLicense).Include(j => j.EducationLevel).Include(j => j.Gender).Include(j => j.Governorates).Include(j => j.LevelArmy).Include(j => j.LevelComputer).Include(j => j.LevelEnglishI).Include(j => j.LevelOffice).Include(j => j.MonthlySalary).Include(j => j.RequiredWorkers).Include(j => j.Timeswork).Include(j => j.Weekend).Include(j => j.WorkHours).Include(j => j.YearsExperience);
            return View(jobs.ToList());
        }

        // GET: Jobs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jobs jobs = db.Jobs.Find(id);
            if (jobs == null)
            {
                return HttpNotFound();
            }
          
            return View(jobs);
        }

        // GET: Jobs/Create
        public ActionResult Create()
        {
            ViewBag.AdvantagesWorkID = new SelectList(db.AdvantagesWorks, "Id", "AdvantagesWorkName");
            ViewBag.AgeID = new SelectList(db.Ages, "Id", "AgeName");
            ViewBag.AlwaysID = new SelectList(db.Always, "Id", "ContinuityName");
            ViewBag.CategoryID = new SelectList(db.Categories, "Id", "CategoryName");
            ViewBag.CitiesID = new SelectList(db.Cities, "Id", "CitiesName");
            ViewBag.CompanyActivityID = new SelectList(db.CompanyActivities, "Id", "CompanyActivityName");
            ViewBag.CountriesID = new SelectList(db.Countries, "Id", "CountriesName");
            ViewBag.DrivingLicenseID = new SelectList(db.DrivingLicenses, "Id", "DrivingLicenseName");
            ViewBag.EducationLevelID = new SelectList(db.EducationLevels, "Id", "EducationLevelName");
            ViewBag.GenderID = new SelectList(db.Genders, "Id", "GenderName");
            ViewBag.GovernoratesID = new SelectList(db.Governorates, "Id", "GovernoratesName");
            ViewBag.LevelArmyID = new SelectList(db.LevelArmies, "Id", "LevelArmyName");
            ViewBag.LevelComputerID = new SelectList(db.LevelComputers, "Id", "LevelComputerName");
            ViewBag.LevelEnglishID = new SelectList(db.LevelEnglishes, "Id", "LevelEnglishName");
            ViewBag.LevelOfficeID = new SelectList(db.LevelOffices, "Id", "LevelOfficeName");
            ViewBag.MonthlySalaryID = new SelectList(db.MonthlySalaries, "Id", "MonthlySalaryName");
            ViewBag.RequiredWorkersID = new SelectList(db.RequiredWorkers, "Id", "RequiredWorkersName");
            ViewBag.TimesworkID = new SelectList(db.Timesworks, "Id", "TimesworkName");
            ViewBag.WeekendID = new SelectList(db.Weekends, "Id", "WeekendName");
            ViewBag.WorkHoursID = new SelectList(db.WorkHours, "Id", "WorkHoursName");
            ViewBag.YearsExperienceID = new SelectList(db.YearsExperiences, "Id", "YearsExperienceName");
            return View();
        }

        // POST: Jobs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Jobs jobs,HttpPostedFileBase upload)
        {
            jobs.JobImage = upload.FileName;
            jobs.UserID = User.Identity.GetUserId();
            jobs.DatePublication = DateTime.Now;
            string path = Path.Combine(Server.MapPath("~/Uploads"), upload.FileName);
            upload.SaveAs(path);
               
            if (ModelState.IsValid)
            {
                db.Jobs.Add(jobs);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AdvantagesWorkID = new SelectList(db.AdvantagesWorks, "Id", "AdvantagesWorkName", jobs.AdvantagesWorkID);
            ViewBag.AgeID = new SelectList(db.Ages, "Id", "AgeName", jobs.AgeID);
            ViewBag.AlwaysID = new SelectList(db.Always, "Id", "ContinuityName", jobs.AlwaysID);
            ViewBag.CategoryID = new SelectList(db.Categories, "Id", "CategoryName", jobs.CategoryID);
            ViewBag.CitiesID = new SelectList(db.Cities, "Id", "CitiesName", jobs.CitiesID);
            ViewBag.CompanyActivityID = new SelectList(db.CompanyActivities, "Id", "CompanyActivityName", jobs.CompanyActivityID);
            ViewBag.CountriesID = new SelectList(db.Countries, "Id", "CountriesName", jobs.CountriesID);
            ViewBag.DrivingLicenseID = new SelectList(db.DrivingLicenses, "Id", "DrivingLicenseName", jobs.DrivingLicenseID);
            ViewBag.EducationLevelID = new SelectList(db.EducationLevels, "Id", "EducationLevelName", jobs.EducationLevelID);
            ViewBag.GenderID = new SelectList(db.Genders, "Id", "GenderName", jobs.GenderID);
            ViewBag.GovernoratesID = new SelectList(db.Governorates, "Id", "GovernoratesName", jobs.GovernoratesID);
            ViewBag.LevelArmyID = new SelectList(db.LevelArmies, "Id", "LevelArmyName", jobs.LevelArmyID);
            ViewBag.LevelComputerID = new SelectList(db.LevelComputers, "Id", "LevelComputerName", jobs.LevelComputerID);
            ViewBag.LevelEnglishID = new SelectList(db.LevelEnglishes, "Id", "LevelEnglishName", jobs.LevelEnglishID);
            ViewBag.LevelOfficeID = new SelectList(db.LevelOffices, "Id", "LevelOfficeName", jobs.LevelOfficeID);
            ViewBag.MonthlySalaryID = new SelectList(db.MonthlySalaries, "Id", "MonthlySalaryName", jobs.MonthlySalaryID);
            ViewBag.RequiredWorkersID = new SelectList(db.RequiredWorkers, "Id", "RequiredWorkersName", jobs.RequiredWorkersID);
            ViewBag.TimesworkID = new SelectList(db.Timesworks, "Id", "TimesworkName", jobs.TimesworkID);
            ViewBag.WeekendID = new SelectList(db.Weekends, "Id", "WeekendName", jobs.WeekendID);
            ViewBag.WorkHoursID = new SelectList(db.WorkHours, "Id", "WorkHoursName", jobs.WorkHoursID);
            ViewBag.YearsExperienceID = new SelectList(db.YearsExperiences, "Id", "YearsExperienceName", jobs.YearsExperienceID);
            return View(jobs);
        }

        // GET: Jobs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jobs jobs = db.Jobs.Find(id);
            if (jobs == null)
            {
                return HttpNotFound();
            }
            ViewBag.AdvantagesWorkID = new SelectList(db.AdvantagesWorks, "Id", "AdvantagesWorkName", jobs.AdvantagesWorkID);
            ViewBag.AgeID = new SelectList(db.Ages, "Id", "AgeName", jobs.AgeID);
            ViewBag.AlwaysID = new SelectList(db.Always, "Id", "ContinuityName", jobs.AlwaysID);
            ViewBag.CategoryID = new SelectList(db.Categories, "Id", "CategoryName", jobs.CategoryID);
            ViewBag.CitiesID = new SelectList(db.Cities, "Id", "CitiesName", jobs.CitiesID);
            ViewBag.CompanyActivityID = new SelectList(db.CompanyActivities, "Id", "CompanyActivityName", jobs.CompanyActivityID);
            ViewBag.CountriesID = new SelectList(db.Countries, "Id", "CountriesName", jobs.CountriesID);
            ViewBag.DrivingLicenseID = new SelectList(db.DrivingLicenses, "Id", "DrivingLicenseName", jobs.DrivingLicenseID);
            ViewBag.EducationLevelID = new SelectList(db.EducationLevels, "Id", "EducationLevelName", jobs.EducationLevelID);
            ViewBag.GenderID = new SelectList(db.Genders, "Id", "GenderName", jobs.GenderID);
            ViewBag.GovernoratesID = new SelectList(db.Governorates, "Id", "GovernoratesName", jobs.GovernoratesID);
            ViewBag.LevelArmyID = new SelectList(db.LevelArmies, "Id", "LevelArmyName", jobs.LevelArmyID);
            ViewBag.LevelComputerID = new SelectList(db.LevelComputers, "Id", "LevelComputerName", jobs.LevelComputerID);
            ViewBag.LevelEnglishID = new SelectList(db.LevelEnglishes, "Id", "LevelEnglishName", jobs.LevelEnglishID);
            ViewBag.LevelOfficeID = new SelectList(db.LevelOffices, "Id", "LevelOfficeName", jobs.LevelOfficeID);
            ViewBag.MonthlySalaryID = new SelectList(db.MonthlySalaries, "Id", "MonthlySalaryName", jobs.MonthlySalaryID);
            ViewBag.RequiredWorkersID = new SelectList(db.RequiredWorkers, "Id", "RequiredWorkersName", jobs.RequiredWorkersID);
            ViewBag.TimesworkID = new SelectList(db.Timesworks, "Id", "TimesworkName", jobs.TimesworkID);
            ViewBag.WeekendID = new SelectList(db.Weekends, "Id", "WeekendName", jobs.WeekendID);
            ViewBag.WorkHoursID = new SelectList(db.WorkHours, "Id", "WorkHoursName", jobs.WorkHoursID);
            ViewBag.YearsExperienceID = new SelectList(db.YearsExperiences, "Id", "YearsExperienceName", jobs.YearsExperienceID);
            return View(jobs);
        }

        // POST: Jobs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Jobs jobs, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                string oldPath = Path.Combine(Server.MapPath("~/Uploads"), jobs.JobImage);
                jobs.UserID = User.Identity.GetUserId();
                jobs.DatePublication = DateTime.Now;
                if (upload != null)
                {
                    System.IO.File.Delete(oldPath);
                    string path = Path.Combine(Server.MapPath("~/Uploads"), upload.FileName);
                    upload.SaveAs(path);
                    jobs.JobImage = upload.FileName;
                }

                db.Entry(jobs).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AdvantagesWorkID = new SelectList(db.AdvantagesWorks, "Id", "AdvantagesWorkName", jobs.AdvantagesWorkID);
            ViewBag.AgeID = new SelectList(db.Ages, "Id", "AgeName", jobs.AgeID);
            ViewBag.AlwaysID = new SelectList(db.Always, "Id", "ContinuityName", jobs.AlwaysID);
            ViewBag.CategoryID = new SelectList(db.Categories, "Id", "CategoryName", jobs.CategoryID);
            ViewBag.CitiesID = new SelectList(db.Cities, "Id", "CitiesName", jobs.CitiesID);
            ViewBag.CompanyActivityID = new SelectList(db.CompanyActivities, "Id", "CompanyActivityName", jobs.CompanyActivityID);
            ViewBag.CountriesID = new SelectList(db.Countries, "Id", "CountriesName", jobs.CountriesID);
            ViewBag.DrivingLicenseID = new SelectList(db.DrivingLicenses, "Id", "DrivingLicenseName", jobs.DrivingLicenseID);
            ViewBag.EducationLevelID = new SelectList(db.EducationLevels, "Id", "EducationLevelName", jobs.EducationLevelID);
            ViewBag.GenderID = new SelectList(db.Genders, "Id", "GenderName", jobs.GenderID);
            ViewBag.GovernoratesID = new SelectList(db.Governorates, "Id", "GovernoratesName", jobs.GovernoratesID);
            ViewBag.LevelArmyID = new SelectList(db.LevelArmies, "Id", "LevelArmyName", jobs.LevelArmyID);
            ViewBag.LevelComputerID = new SelectList(db.LevelComputers, "Id", "LevelComputerName", jobs.LevelComputerID);
            ViewBag.LevelEnglishID = new SelectList(db.LevelEnglishes, "Id", "LevelEnglishName", jobs.LevelEnglishID);
            ViewBag.LevelOfficeID = new SelectList(db.LevelOffices, "Id", "LevelOfficeName", jobs.LevelOfficeID);
            ViewBag.MonthlySalaryID = new SelectList(db.MonthlySalaries, "Id", "MonthlySalaryName", jobs.MonthlySalaryID);
            ViewBag.RequiredWorkersID = new SelectList(db.RequiredWorkers, "Id", "RequiredWorkersName", jobs.RequiredWorkersID);
            ViewBag.TimesworkID = new SelectList(db.Timesworks, "Id", "TimesworkName", jobs.TimesworkID);
            ViewBag.WeekendID = new SelectList(db.Weekends, "Id", "WeekendName", jobs.WeekendID);
            ViewBag.WorkHoursID = new SelectList(db.WorkHours, "Id", "WorkHoursName", jobs.WorkHoursID);
            ViewBag.YearsExperienceID = new SelectList(db.YearsExperiences, "Id", "YearsExperienceName", jobs.YearsExperienceID);
            return View(jobs);
        }

        // GET: Jobs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jobs jobs = db.Jobs.Find(id);
            if (jobs == null)
            {
                return HttpNotFound();
            }
            return View(jobs);
        }

        // POST: Jobs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Jobs jobs = db.Jobs.Find(id);
            db.Jobs.Remove(jobs);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetGovernorates(int id)
        {
            List<Governorates> GovernoratesList = db.Governorates.Where(x => x.CountriesID == id).ToList();
            ViewBag.GovernoratesLists = new SelectList(GovernoratesList, "Id", "GovernoratesName");
            return PartialView("DisplayGovernorates");
        }
        public ActionResult GetCities(int id)
        {
            List<Cities> CitiesList = db.Cities.Where(x => x.GovernoratesID == id).ToList();
            ViewBag.CitiesLists = new SelectList(CitiesList, "Id", "CitiesName");
            return PartialView("DisplayCities");
        }
        public ActionResult GetJobsWithCity(int id)
        {
            ViewBag.CurrentUser = User.Identity.GetUserId();
            ApplicationUser userinfo = db.Users.Find(ViewBag.CurrentUser);
            ViewBag.userType = userinfo.UserType;
            var jobs = db.Jobs.Where(j => j.GovernoratesID == id).ToList();
            return View(jobs);
        }

        public ActionResult GetJobsWithCatgory(int id)
        {
            ViewBag.CurrentUser = User.Identity.GetUserId();
            ApplicationUser userinfo = db.Users.Find(ViewBag.CurrentUser);
            ViewBag.userType = userinfo.UserType;
            var jobs = db.Jobs.Where(j => j.CategoryID == id).ToList();
            return View(jobs);
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

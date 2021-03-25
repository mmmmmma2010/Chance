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
using WebApplication1;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using System.IO;
using System.Data.Entity.Validation;

namespace Give_Pro.Controllers
{
    public class ResearcherProfilesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;




        public ResearcherProfilesController()
        {
            /* ييمثل قاعده البيانات */
            db = new ApplicationDbContext();

        }
        public ResearcherProfilesController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        // GET: ResearcherProfiles
        public ActionResult Index()
        {
            var researcherProfiles = db.ResearcherProfiles.Include(r => r.Age).Include(r => r.Cities).Include(r => r.CompanyActivity).Include(r => r.Countries).Include(r => r.DrivingLicense).Include(r => r.EducationLevel).Include(r => r.Gender).Include(r => r.Governorates).Include(r => r.LevelArmy).Include(r => r.LevelComputer).Include(r => r.LevelEnglish).Include(r => r.LevelOffice).Include(r => r.Nationalities).Include(r => r.User).Include(r => r.YearsExperience);
            return View(researcherProfiles.ToList());
        }

        // GET: ResearcherProfiles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResearcherProfile researcherProfile = db.ResearcherProfiles.Find(id);
            if (researcherProfile == null)
            {
                return HttpNotFound();
            }
            return View(researcherProfile);
        }

        // GET: ResearcherProfiles/Create
        public ActionResult Create()
        {
            ViewBag.AgeID = new SelectList(db.Ages, "Id", "AgeName");
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
            ViewBag.NationalitiesID = new SelectList(db.Nationalities, "Id", "NationalitiesName");
            //ViewBag.UserID = new SelectList(db.ApplicationUsers, "Id", "UserType");
            ViewBag.YearsExperienceID = new SelectList(db.YearsExperiences, "Id", "YearsExperienceName");
            return View();
        }

        // POST: ResearcherProfiles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FullName,NumberCard,DateEnd,DateBirth,AgeID,NationalitiesID,GenderID,NumberPhone,CountriesID,GovernoratesID,CitiesID,AddressDetails,DrivingLicenseID,EducationLevelID,LevelEnglishID,LevelComputerID,LevelOfficeID,LevelArmyID,CompanyActivityID,YearsExperienceID,FileCV,Password,UserID")] ResearcherProfile researcherProfile, HttpPostedFileBase uploadCV)
        {
            var UserID = User.Identity.GetUserId();/*هنا بيجيب معرف المستخدم الحالى*/
            var CurrentUser = db.Users.Where(a => a.Id == UserID).SingleOrDefault();
             researcherProfile.UserID =UserID;
             researcherProfile.FileCV = uploadCV.FileName;
            /* التحقق من كلمة السر القديمة */
            if (!UserManager.CheckPassword(CurrentUser, researcherProfile.Password))
            {
                ViewBag.Message = "كلمة السر الحالية غير صحيحة";
            }
            else
            {

                if (ModelState.IsValid)
                {

                    string CV_Path = Path.Combine(Server.MapPath("~/Uploads/CVs"), uploadCV.FileName);
                    

                    uploadCV.SaveAs(CV_Path);

                    /* التحزين فـ قواعد البيانات */
                    //RS.Image = uploadIm.FileName;

                   
                    researcherProfile.Password = null;

                    db.ResearcherProfiles.Add(researcherProfile);
                    try
                    {
                        db.SaveChanges();
                    }
                    catch (DbEntityValidationException e)
                    {
                        Console.WriteLine(e);
                    }
                    ViewBag.Message = "تمت عملية التحديث بـ نجاح";
                }
                return RedirectToAction("Edit");
            }

                ViewBag.AgeID = new SelectList(db.Ages, "Id", "AgeName", researcherProfile.AgeID);
            ViewBag.CitiesID = new SelectList(db.Cities, "Id", "CitiesName", researcherProfile.CitiesID);
            ViewBag.CompanyActivityID = new SelectList(db.CompanyActivities, "Id", "CompanyActivityName", researcherProfile.CompanyActivityID);
            ViewBag.CountriesID = new SelectList(db.Countries, "Id", "CountriesName", researcherProfile.CountriesID);
            ViewBag.DrivingLicenseID = new SelectList(db.DrivingLicenses, "Id", "DrivingLicenseName", researcherProfile.DrivingLicenseID);
            ViewBag.EducationLevelID = new SelectList(db.EducationLevels, "Id", "EducationLevelName", researcherProfile.EducationLevelID);
            ViewBag.GenderID = new SelectList(db.Genders, "Id", "GenderName", researcherProfile.GenderID);
            ViewBag.GovernoratesID = new SelectList(db.Governorates, "Id", "GovernoratesName", researcherProfile.GovernoratesID);
            ViewBag.LevelArmyID = new SelectList(db.LevelArmies, "Id", "LevelArmyName", researcherProfile.LevelArmyID);
            ViewBag.LevelComputerID = new SelectList(db.LevelComputers, "Id", "LevelComputerName", researcherProfile.LevelComputerID);
            ViewBag.LevelEnglishID = new SelectList(db.LevelEnglishes, "Id", "LevelEnglishName", researcherProfile.LevelEnglishID);
            ViewBag.LevelOfficeID = new SelectList(db.LevelOffices, "Id", "LevelOfficeName", researcherProfile.LevelOfficeID);
            ViewBag.NationalitiesID = new SelectList(db.Nationalities, "Id", "NationalitiesName", researcherProfile.NationalitiesID);
            //ViewBag.UserID = new SelectList(db.ApplicationUsers, "Id", "UserType", researcherProfile.UserID);
            ViewBag.YearsExperienceID = new SelectList(db.YearsExperiences, "Id", "YearsExperienceName", researcherProfile.YearsExperienceID);
            return View(researcherProfile);
        }

        // GET: ResearcherProfiles/Edit/5
        public ActionResult Edit()
        {
            var UserID = User.Identity.GetUserId();/*هنا بيجيب معرف المستخدم الحالى*/

            var there = db.ResearcherProfiles.Where(R => R.UserID == UserID).SingleOrDefault();
            if (there == null)
            {
                return RedirectToAction("Create");
            }
            else
            {
                var researcherProfile = db.ResearcherProfiles.Where(a => a.UserID == UserID).SingleOrDefault();
                ViewBag.AgeID = new SelectList(db.Ages, "Id", "AgeName", researcherProfile.AgeID);
                ViewBag.CitiesID = new SelectList(db.Cities, "Id", "CitiesName", researcherProfile.CitiesID);
                ViewBag.CompanyActivityID = new SelectList(db.CompanyActivities, "Id", "CompanyActivityName", researcherProfile.CompanyActivityID);
                ViewBag.CountriesID = new SelectList(db.Countries, "Id", "CountriesName", researcherProfile.CountriesID);
                ViewBag.DrivingLicenseID = new SelectList(db.DrivingLicenses, "Id", "DrivingLicenseName", researcherProfile.DrivingLicenseID);
                ViewBag.EducationLevelID = new SelectList(db.EducationLevels, "Id", "EducationLevelName", researcherProfile.EducationLevelID);
                ViewBag.GenderID = new SelectList(db.Genders, "Id", "GenderName", researcherProfile.GenderID);
                ViewBag.GovernoratesID = new SelectList(db.Governorates, "Id", "GovernoratesName", researcherProfile.GovernoratesID);
                ViewBag.LevelArmyID = new SelectList(db.LevelArmies, "Id", "LevelArmyName", researcherProfile.LevelArmyID);
                ViewBag.LevelComputerID = new SelectList(db.LevelComputers, "Id", "LevelComputerName", researcherProfile.LevelComputerID);
                ViewBag.LevelEnglishID = new SelectList(db.LevelEnglishes, "Id", "LevelEnglishName", researcherProfile.LevelEnglishID);
                ViewBag.LevelOfficeID = new SelectList(db.LevelOffices, "Id", "LevelOfficeName", researcherProfile.LevelOfficeID);
                ViewBag.NationalitiesID = new SelectList(db.Nationalities, "Id", "NationalitiesName", researcherProfile.NationalitiesID);
                //ViewBag.UserID = new SelectList(db.ApplicationUsers, "Id", "UserType", researcherProfile.UserID);
                ViewBag.YearsExperienceID = new SelectList(db.YearsExperiences, "Id", "YearsExperienceName", researcherProfile.YearsExperienceID);
                return View(researcherProfile);
            }
        }

        // POST: ResearcherProfiles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FullName,NumberCard,DateEnd,DateBirth,AgeID,NationalitiesID,GenderID,NumberPhone,CountriesID,GovernoratesID,CitiesID,AddressDetails,DrivingLicenseID,EducationLevelID,LevelEnglishID,LevelComputerID,LevelOfficeID,LevelArmyID,CompanyActivityID,YearsExperienceID,FileCV,Password,UserID")] ResearcherProfile researcherProfile,HttpPostedFileBase uploadCV)
        {
            var UserID = User.Identity.GetUserId();
            var CurrentUser = db.Users.Where(a => a.Id == UserID).SingleOrDefault();
            

            /* التحقق من كلمة السر القديمة */
            if (researcherProfile.Password == null || !UserManager.CheckPassword(CurrentUser, researcherProfile.Password))
            {
                ViewBag.Message = "كلمة السر الحالية غير صحيحة";
            }
            else
            {
                if (ModelState.IsValid)
                {
                    /*المسار القديم */

                    //string oldImagePath = Path.Combine(Server.MapPath("~/Uploads"), profile.Image);
                    string oldCVPath = Path.Combine(Server.MapPath("~/Uploads/CVs"), researcherProfile.FileCV);



                    ///* إذا تم رفع الملف */
                    ////هنفصلهم عن بعض
                    //if (uploadIm != null)
                    //{
                    //    System.IO.File.Delete(oldImagePath);

                    //    /* تخزين المسار علي السيرفر */
                    //    /* المسار الذي اريد الحفظ عليه بدمج مسارين الاول ف السيرفر والتاني اسم الصورة ب اسم */
                    //    string Imagepath = Path.Combine(Server.MapPath("~/Uploads"), uploadIm.FileName);

                    //    uploadIm.SaveAs(Imagepath);
                    //    /* التحزين فـ قواعد البيانات */
                    //    profile.Image = uploadIm.FileName;

                    //}
                    if (uploadCV != null)
                    {
                        System.IO.File.Delete(oldCVPath);

                        /* تخزين المسار علي السيرفر */
                        /* المسار الذي اريد الحفظ عليه بدمج مسارين الاول ف السيرفر والتاني اسم الصورة ب اسم */
                        string CV_path = Path.Combine(Server.MapPath("~/Uploads/CVs"), uploadCV.FileName);
                        
                        uploadCV.SaveAs(CV_path);
                        /* التحزين فـ قواعد البيانات */
                        researcherProfile.FileCV = uploadCV.FileName;

                    }

                    /* حفظ الباسورد ب طريقة التشفير */

                    researcherProfile.Password = null;

                    db.Entry(researcherProfile).State = EntityState.Modified;
                    try
                    {
                        db.SaveChanges();
                    }
                    catch (DbEntityValidationException e)
                    { Console.WriteLine(e); }
                    ViewBag.Message = "تمت عملية التحديث بـ نجاح";
                }
            }
            ViewBag.AgeID = new SelectList(db.Ages, "Id", "AgeName", researcherProfile.AgeID);
            ViewBag.CitiesID = new SelectList(db.Cities, "Id", "CitiesName", researcherProfile.CitiesID);
            ViewBag.CompanyActivityID = new SelectList(db.CompanyActivities, "Id", "CompanyActivityName", researcherProfile.CompanyActivityID);
            ViewBag.CountriesID = new SelectList(db.Countries, "Id", "CountriesName", researcherProfile.CountriesID);
            ViewBag.DrivingLicenseID = new SelectList(db.DrivingLicenses, "Id", "DrivingLicenseName", researcherProfile.DrivingLicenseID);
            ViewBag.EducationLevelID = new SelectList(db.EducationLevels, "Id", "EducationLevelName", researcherProfile.EducationLevelID);
            ViewBag.GenderID = new SelectList(db.Genders, "Id", "GenderName", researcherProfile.GenderID);
            ViewBag.GovernoratesID = new SelectList(db.Governorates, "Id", "GovernoratesName", researcherProfile.GovernoratesID);
            ViewBag.LevelArmyID = new SelectList(db.LevelArmies, "Id", "LevelArmyName", researcherProfile.LevelArmyID);
            ViewBag.LevelComputerID = new SelectList(db.LevelComputers, "Id", "LevelComputerName", researcherProfile.LevelComputerID);
            ViewBag.LevelEnglishID = new SelectList(db.LevelEnglishes, "Id", "LevelEnglishName", researcherProfile.LevelEnglishID);
            ViewBag.LevelOfficeID = new SelectList(db.LevelOffices, "Id", "LevelOfficeName", researcherProfile.LevelOfficeID);
            ViewBag.NationalitiesID = new SelectList(db.Nationalities, "Id", "NationalitiesName", researcherProfile.NationalitiesID);
            //ViewBag.UserID = new SelectList(db.ApplicationUsers, "Id", "UserType", researcherProfile.UserID);
            ViewBag.YearsExperienceID = new SelectList(db.YearsExperiences, "Id", "YearsExperienceName", researcherProfile.YearsExperienceID);
            return View(researcherProfile);
        }

        // GET: ResearcherProfiles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResearcherProfile researcherProfile = db.ResearcherProfiles.Find(id);
            if (researcherProfile == null)
            {
                return HttpNotFound();
            }
            return View(researcherProfile);
        }

        // POST: ResearcherProfiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ResearcherProfile researcherProfile = db.ResearcherProfiles.Find(id);
            db.ResearcherProfiles.Remove(researcherProfile);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetCV(string fileName)
        {
            string filePath = "~/Uploads/CVs/" + fileName;
            return File(filePath, "application/pdf");

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

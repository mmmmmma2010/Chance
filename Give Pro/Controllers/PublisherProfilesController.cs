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
    public class PublisherProfilesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;




        public PublisherProfilesController()
        {
            /* ييمثل قاعده البيانات */
            db = new ApplicationDbContext();

        }
        public PublisherProfilesController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
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


        // GET: PublisherProfiles
        public ActionResult Index()
        {
            var publisherProfiles = db.PublisherProfiles.Include(p => p.Cities).Include(p => p.CompanyActivity).Include(p => p.Countries).Include(p => p.Governorates).Include(p => p.StaffSize).Include(p => p.Timeswork).Include(p => p.User);
            return View(publisherProfiles.ToList());
        }

        // GET: PublisherProfiles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PublisherProfile publisherProfile = db.PublisherProfiles.Find(id);
            if (publisherProfile == null)
            {
                return HttpNotFound();
            }
            return View(publisherProfile);
        }

        // GET: PublisherProfiles/Create
        public ActionResult Create()
        {
            ViewBag.CitiesID = new SelectList(db.Cities, "Id", "CitiesName");
            ViewBag.CompanyActivityID = new SelectList(db.CompanyActivities, "Id", "CompanyActivityName");
            ViewBag.CountriesID = new SelectList(db.Countries, "Id", "CountriesName");
            ViewBag.GovernoratesID = new SelectList(db.Governorates, "Id", "GovernoratesName");
            ViewBag.StaffSizeID = new SelectList(db.StaffSizes, "Id", "StaffSizeName");
            ViewBag.TimesworkID = new SelectList(db.Timesworks, "Id", "TimesworkName");
            //ViewBag.UserID = new SelectList(db.ApplicationUsers, "Id", "UserType");
            var UserID = User.Identity.GetUserId();/*هنا بيجيب معرف المستخدم الحالى*/
            var user = db.Users.Where(a => a.Id == UserID).SingleOrDefault();/*بيجيب المستخدم من قاعدةالبيانات*/
            PublisherProfile PBprofile = new PublisherProfile();
            PBprofile.UserID = UserID;
            PBprofile.Email = user.Email;
            PBprofile.DateBirth = DateTime.Now.ToShortDateString();
            PBprofile.DateEnd = DateTime.Now.ToShortDateString();
            return View(PBprofile);
        }

        // POST: PublisherProfiles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PublisherProfile publisherProfile, HttpPostedFileBase upload, HttpPostedFileBase uploadLegalPaper)
        {
            var UserID = User.Identity.GetUserId();/*هنا بيجيب معرف المستخدم الحالى*/
            var CurrentUser = db.Users.Where(a => a.Id == UserID).SingleOrDefault();
            publisherProfile.CompLogo = upload.FileName;
            publisherProfile.LegalPaper = uploadLegalPaper.FileName;
            publisherProfile.UserID = UserID;

            /* التحقق من كلمة السر القديمة */
            if (publisherProfile.Password == null || !UserManager.CheckPassword(CurrentUser, publisherProfile.Password))
            {
                ViewBag.Message = "كلمة السر الحالية غير صحيحة";
            }
            else
            {


                if (ModelState.IsValid)
                {
                    publisherProfile.Password =null;
                    /* تخزين المسار علي السيرفر */
                    /* المسار الذي اريد الحفظ عليه بدمج مسارين الاول ف السيرفر والتاني اسم الصورة ب اسم */

                    string CV_Path = Path.Combine(Server.MapPath("~/Uploads/CVs"), uploadLegalPaper.FileName);
                    string path = Path.Combine(Server.MapPath("~/Uploads"), upload.FileName);
                    upload.SaveAs(path);
                    uploadLegalPaper.SaveAs(CV_Path);

                    /* التحزين فـ قواعد البيانات */


                    db.PublisherProfiles.Add(publisherProfile);
                    try
                    {
                        db.SaveChanges();
                    }
                    catch (DbEntityValidationException e)
                    {
                        Console.WriteLine(e);
                    }
                    ViewBag.Message = "تمت عملية التحديث بـ نجاح";
                    return RedirectToAction("Edit");
                }


            }

            ViewBag.CitiesID = new SelectList(db.Cities, "Id", "CitiesName", publisherProfile.CitiesID);
            ViewBag.CompanyActivityID = new SelectList(db.CompanyActivities, "Id", "CompanyActivityName", publisherProfile.CompanyActivityID);
            ViewBag.CountriesID = new SelectList(db.Countries, "Id", "CountriesName", publisherProfile.CountriesID);
            ViewBag.GovernoratesID = new SelectList(db.Governorates, "Id", "GovernoratesName", publisherProfile.GovernoratesID);
            ViewBag.StaffSizeID = new SelectList(db.StaffSizes, "Id", "StaffSizeName", publisherProfile.StaffSizeID);
            ViewBag.TimesworkID = new SelectList(db.Timesworks, "Id", "TimesworkName", publisherProfile.TimesworkID);
            //ViewBag.UserID = new SelectList(db.ApplicationUsers, "Id", "UserType", publisherProfile.UserID);
            return View(publisherProfile);
        }

        // GET: PublisherProfiles/Edit/5
        public ActionResult Edit()
        {
            var UserID = User.Identity.GetUserId();/*هنا بيجيب معرف المستخدم الحالى*/
            var there = db.PublisherProfiles.Where(a => a.UserID == UserID).SingleOrDefault();
            if (there == null)
            {
                return RedirectToAction("Create");
            }
            var publisherProfile = db.PublisherProfiles.Where(a => a.UserID == UserID).SingleOrDefault();
            ViewBag.CitiesID = new SelectList(db.Cities, "Id", "CitiesName", publisherProfile.CitiesID);
            ViewBag.CompanyActivityID = new SelectList(db.CompanyActivities, "Id", "CompanyActivityName", publisherProfile.CompanyActivityID);
            ViewBag.CountriesID = new SelectList(db.Countries, "Id", "CountriesName", publisherProfile.CountriesID);
            ViewBag.GovernoratesID = new SelectList(db.Governorates, "Id", "GovernoratesName", publisherProfile.GovernoratesID);
            ViewBag.StaffSizeID = new SelectList(db.StaffSizes, "Id", "StaffSizeName", publisherProfile.StaffSizeID);
            ViewBag.TimesworkID = new SelectList(db.Timesworks, "Id", "TimesworkName", publisherProfile.TimesworkID);
            //ViewBag.UserID = new SelectList(db.ApplicationUsers, "Id", "UserType", publisherProfile.UserID);
            return View(publisherProfile);
        }

        // POST: PublisherProfiles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PublisherProfile publisherProfile, HttpPostedFileBase upload, HttpPostedFileBase uploadLegalPaper)
        {
            var UserID = User.Identity.GetUserId();
            var CurrentUser = db.Users.Where(a => a.Id == UserID).SingleOrDefault();


            /* التحقق من كلمة السر القديمة */
            if (publisherProfile.Password == null || !UserManager.CheckPassword(CurrentUser, publisherProfile.Password))
            {
                ViewBag.Message = "كلمة السر الحالية غير صحيحة";

            }
            else
            {
                if (ModelState.IsValid)
                {
                    /*المسار القديم */

                    string oldPath = Path.Combine(Server.MapPath("~/Uploads"), publisherProfile.CompLogo);
                    string oldLegalPaperPath = Path.Combine(Server.MapPath("~/Uploads/CVs"), publisherProfile.LegalPaper);

                    /* إذا تم رفع الملف */

                    if (upload != null)
                    {
                        System.IO.File.Delete(oldPath);
                        /* تخزين المسار علي السيرفر */
                        /* المسار الذي اريد الحفظ عليه بدمج مسارين الاول ف السيرفر والتاني اسم الصورة ب اسم */
                        string path = Path.Combine(Server.MapPath("~/Uploads"), upload.FileName);
                        upload.SaveAs(path);
                        /* التحزين فـ قواعد البيانات */
                        publisherProfile.CompLogo = upload.FileName;

                    }
                    if (uploadLegalPaper != null)
                    {
                        System.IO.File.Delete(oldLegalPaperPath);
                        /* تخزين المسار علي السيرفر */
                        /* المسار الذي اريد الحفظ عليه بدمج مسارين الاول ف السيرفر والتاني اسم الصورة ب اسم */
                        string LegalPaperpath = Path.Combine(Server.MapPath("~/Uploads/CVs"), uploadLegalPaper.FileName);
                        uploadLegalPaper.SaveAs(LegalPaperpath);
                        /* التحزين فـ قواعد البيانات */
                        publisherProfile.LegalPaper = uploadLegalPaper.FileName;

                    }


                    publisherProfile.Password = null;

                    db.Entry(publisherProfile).State = EntityState.Modified;
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
            }
            ViewBag.CitiesID = new SelectList(db.Cities, "Id", "CitiesName", publisherProfile.CitiesID);
            ViewBag.CompanyActivityID = new SelectList(db.CompanyActivities, "Id", "CompanyActivityName", publisherProfile.CompanyActivityID);
            ViewBag.CountriesID = new SelectList(db.Countries, "Id", "CountriesName", publisherProfile.CountriesID);
            ViewBag.GovernoratesID = new SelectList(db.Governorates, "Id", "GovernoratesName", publisherProfile.GovernoratesID);
            ViewBag.StaffSizeID = new SelectList(db.StaffSizes, "Id", "StaffSizeName", publisherProfile.StaffSizeID);
            ViewBag.TimesworkID = new SelectList(db.Timesworks, "Id", "TimesworkName", publisherProfile.TimesworkID);
            //ViewBag.UserID = new SelectList(db.ApplicationUsers, "Id", "UserType", publisherProfile.UserID);
            return View(publisherProfile);
        }

        // GET: PublisherProfiles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PublisherProfile publisherProfile = db.PublisherProfiles.Find(id);
            if (publisherProfile == null)
            {
                return HttpNotFound();
            }
            return View(publisherProfile);
        }

        // POST: PublisherProfiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PublisherProfile publisherProfile = db.PublisherProfiles.Find(id);
            db.PublisherProfiles.Remove(publisherProfile);
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

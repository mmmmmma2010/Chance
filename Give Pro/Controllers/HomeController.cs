using Give_Pro.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {

            ViewBag.categories = db.Categories.ToList();
            ViewBag.jobs = db.Jobs.Where(j => j.DatePublication.Day == DateTime.Now.Day).ToList();

            return View();

            //return View(db.Categories.ToList());
        }

        public ActionResult Details(int JobId)
        {
            var job = db.Jobs.Find(JobId);

            if (job == null)
            {
                return HttpNotFound();
            }
            Session["JobId"] = JobId;
            return View(job);
        }
        [Authorize]
        public ActionResult Apply()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Apply(string Message)
        {
            var UserId = User.Identity.GetUserId();
            var JobId = (int)Session["JobId"];
            var JobInfo = db.Jobs.Where(j => j.Id == JobId).SingleOrDefault();/*بيجيب بيانات الوظيفة */
            var UserProf = new ResearcherProfile();
            var UserInfo = db.Users.Where(u => u.Id == UserId).SingleOrDefault();/*بيجيب بيانات المستخدم*/
            if (UserInfo.UserType == "الباحثون")
            {
                UserProf = db.ResearcherProfiles.Where(u => u.UserID == UserId).SingleOrDefault();  /*بيجيب بيانات بروفايل المستخدم*/
                if (UserProf == null)
                {
                    return RedirectToAction("Create", "ResearcherProfiles");


                }
                else
                {
                    int Rate = 0;/*النسبة اللى هيتم الفلترة على اساسها*/
                                 /* الحصول على النسبة عن طريق مقارنة بعض الحقول المشتركة بين الطرفين*/
                                 //if (JobInfo.Agerequired <= UserProf.Age)
                                 //{ Rate += 20; }
                    if (JobInfo.YearsExperienceID <= UserProf.YearsExperienceID)
                    { Rate += 20; }
                    if (JobInfo.GenderID == (UserProf.GenderID))
                    { Rate += 20; }
                    if (JobInfo.CompanyActivityID == UserProf.CompanyActivityID)
                    { Rate += 20; }
                    if (JobInfo.EducationLevel.Id <= UserProf.EducationLevelID)/*لما نعمل DropDownList هنغير الخانة دى ونخليها تاخد Id بس*/
                    { Rate += 20; }
                    /***********************************************************
                     * *********************************************************
                     *                       ***********************************/
                    /* إذهب إلي جدول تقديم إلي وظيفة وابحث عن اي عنصر المعرف بتاعه يساوي 
                     * معرف الموجود عندي حاليا ومعرف المستخدم يساوي الموجود حاليا 
                     * إذا وجد
                     * نفذ الاتي */
                    var check = db.ApplyForJobs.Where(a => a.JobsId == JobId && a.UserId == UserId).ToList();

                    /* إذا لا يوجد نفذ الاتي */
                    if (check.Count < 1)
                    {

                        var job = new ApplyForJob();
                        job.UserId = UserId;
                        job.JobsId = JobId;
                        job.Message = Message;
                        job.ApplyDate = DateTime.Now;
                        job.Rate = Rate;
                        job.CV = UserProf.FileCV;

                        db.ApplyForJobs.Add(job);
                        db.SaveChanges();

                        ViewBag.Result = "تمت الإضافة بـ نجاح";
                    }
                    else
                    {
                        ViewBag.Result = "المعذرة، لقد سبق وتقدمت إلي نفس الوظيفة";
                        Rate = 0;
                    }
                }
            }
            return View();

        }

        [Authorize]
        public ActionResult GetJobsByUser()
        {
            var UserID = User.Identity.GetUserId();
            var Jobs = db.ApplyForJobs.Where(a => a.UserId == UserID);
            return View(Jobs.ToList());
        }

        [Authorize]
        public ActionResult DetailsOfJob(int Id)
        {
            var job = db.ApplyForJobs.Find(Id);

            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }
        // GET: Roles/Edit/5
        public ActionResult Edit(int id)
        {
            var job = db.ApplyForJobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        // POST: Roles/Edit/5
        [HttpPost]
        public ActionResult Edit(ApplyForJob job)
        {
            if (ModelState.IsValid)
            {
                job.ApplyDate = DateTime.Now;
                db.Entry(job).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("GetJobsByUser");
            }
            return View(job);

        }

        // GET: Roles/Delete/5
        public ActionResult Delete(int id)
        {
            var job = db.ApplyForJobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        // POST: Roles/Delete/5
        [HttpPost]
        public ActionResult Delete(ApplyForJob job)
        {
            // TODO: Add delete logic here
            var myjob = db.ApplyForJobs.Find(job.Id);
            db.ApplyForJobs.Remove(myjob);
            db.SaveChanges();
            return RedirectToAction("GetJobsByUser");

        }

        public ActionResult GetJobsByPublisher()
        {
            var UserID = User.Identity.GetUserId();
            var o = db.ApplyForJobs.Where(a => a.Jobs.UserID == UserID).ToList();
            if (o.Count < 1)
            {
                ViewBag.NoData = "لا توجد وظائف تم التقدم اليها حتى الان.";

            }
            /* لـ تحزين كل الوظائف المسجله ف جدول التقديمات ل متغير الابلكيشن */
            /* عملنا ربط بين جدول المتقدمات والوظائف 
             * جلبنا كل الوظائف ب بياناتها جميعا */
            var Jobs = from app in db.ApplyForJobs
                       join job in db.Jobs
                       on app.JobsId equals job.Id
                       where job.User.Id == UserID
                       select app;
            var sortedJobs = Jobs.ToList().OrderByDescending(a => a.Rate);
            /* خاص بـ عرض كل المتقدمين ل نفس الوظيفة */
            /* إنشاءنا متغير جروبد يذهب إلي قائمةا لوظائف ويعمل تجميع ل عنوانين الوظائف
             * ويخزنها ف الوظائف فيو موديل
             * يخزن عنوان الوظيفة والمتقدمين ك مجموعات 
             * رجعنا النتيجة ع شكل قائمة */


            var grouped = from j in sortedJobs
                          group j by j.Jobs.JobName
                          into gr
                          select new JobsViewModel
                          {
                              JobName = gr.Key,
                              Items = gr
                          };


            return View(grouped.ToList());


        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Contact(ContactModel contact)
        {
            var mail = new MailMessage();
            var logininfo = new NetworkCredential("G.M.Chance00@gmail.com", "012345789");
            mail.From = new MailAddress(contact.Email);
            mail.To.Add(new MailAddress("G.M.Chance00@gmail.com"));
            mail.Subject = contact.Subject;

            mail.IsBodyHtml = true;
            string body = "أسم المرسل : " + contact.Name + "<br>" +
                "بريد المرسل : " + contact.Email + "<br>" +
                "عنوان الرسالة : " + contact.Subject + "<br>" +
                "موضوع الرسالة : <b> " + contact.Message + "</b>";

            mail.Body = body;

            var smtpclient = new SmtpClient("smtp.gmail.com", 587);
            smtpclient.EnableSsl = true;
            smtpclient.Credentials = logininfo;
            smtpclient.Send(mail);

            return RedirectToAction("Index");
        }
        //public ActionResult Search()
        //{
        //    return View();
        //}
        //[HttpPost]
        [Authorize]
        public ActionResult Search(string SearchName)
        {
            if (!String.IsNullOrEmpty(SearchName))
            {
                ViewBag.CurrentUser = User.Identity.GetUserId();
                ApplicationUser userinfo = db.Users.Find(ViewBag.CurrentUser);
                ViewBag.userType = userinfo.UserType;
                var result = db.Jobs.Where(a => a.JobName.Contains(SearchName)

            || a.LevelComputer.LevelComputerName.Contains(SearchName)
            || a.Category.CategoryName.Contains(SearchName)
            || a.Governorates.GovernoratesName.Contains(SearchName)).ToList();
                if (result.Count>0)
                { return View(result); }
                else {
                    ViewBag.none = " #  لم يتم ايجاد وظائف بكلمات البحث تلك" + SearchName;
                    return View("Index");
                    }
            }
            else {
                ViewBag.none = "برجاء ادخال كلمات البحث " ;
                return View("Index"); }
            
        }
    }
}
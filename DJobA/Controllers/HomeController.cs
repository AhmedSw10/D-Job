using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using hhhhh.Models;
using Microsoft.AspNet.Identity;
using DJobA.Models;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace hhhhh.Controllers
{

    public class HomeController : Controller

    {
        private ApplicationDbContext DB = new ApplicationDbContext();
        public ActionResult Index()
        {

            return View(DB.Categories.ToList());
        }


        public ActionResult Details(int JobId)
        {
            var Job = DB.Jobs.Find(JobId);
            if (Job == null)
            {
                return HttpNotFound();

            }
            Session["JobId"] = JobId;
            return View(Job);
        }
        [Authorize]
        public ActionResult GetJobsByUser()
        {
            var UserId = User.Identity.GetUserId();
            var Jobs = DB.ApplyForJobs.Where(a => a.UserId == UserId);

            return View(Jobs.ToList());
        }
        [Authorize]
        public ActionResult GetJobByPublisher()
        {
           var UserName = User.Identity.GetUserName();
            var UserId = User.Identity.GetUserId();

         
            
            var jobs = from app in DB.ApplyForJobs
                       join job in DB.Jobs
                       on app.JobId equals job.Id
                       where job.User.Id == UserId
                       select app;

            return View(jobs.ToList());

        }


        public ActionResult Edit(int id)
        {
            var joob = DB.ApplyForJobs.Find(id);
            if (joob == null)
            {
                return HttpNotFound();
            }
            return View(joob);
        }

        [HttpPost]
        public ActionResult Edit(ApplyForJob joob)
        {
            if (ModelState.IsValid)
            {
                joob.ApplyDate = DateTime.Now;
                DB.Entry(joob).State = EntityState.Modified;
                DB.SaveChanges();
                return RedirectToAction("GetJobsByUser");
            }
            return View(joob);
        }



        public ActionResult Delete(int id)
        {
            var E = DB.ApplyForJobs.Find(id);
            if (E == null)
            {
                return HttpNotFound();
            }
            return View(E);
        }

        // POST: Roles/Delete/5
        [HttpPost]
        public ActionResult Delete(ApplyForJob joob)
        {
            if (ModelState.IsValid)
            {
                var mye= DB.ApplyForJobs.Find(joob.Id);
                DB.ApplyForJobs.Remove(mye);
                DB.SaveChanges();
                return RedirectToAction("GetJobsByUser");
            }
            return View(joob);
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

            var check = DB.ApplyForJobs.Where(a => a.JobId == JobId && a.UserId == UserId).ToList();

            if(check.Count < 1)
            {
                var job = new ApplyForJob();

                job.UserId = UserId;
                job.JobId = JobId;
                job.Message = Message;
                
                job.ApplyDate = DateTime.Now;
                DB.ApplyForJobs.Add(job);
                DB.SaveChanges();
                ViewBag.Result = "Your Request has been sent Successfully";
            }
            else
            {
                ViewBag.Result = "You have been already sent request to same Job";
            }

           


            return View();
        }




        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult DetailsOfJob(int Id)
        {
            var Job = DB.ApplyForJobs.Find(Id);
            if (Job == null)
            {
                return HttpNotFound();

            }
            
            return View(Job);

            
        }
    }
}
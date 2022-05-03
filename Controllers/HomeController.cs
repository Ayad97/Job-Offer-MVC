using ASP_IDENTITY.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP_IDENTITY.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            var list = db.Categories.ToList();
            return View(list);
        } 
        public ActionResult Services()
        {
            var list = db.Categories.ToList();
            return View(list);
        }

        public ActionResult Details(int jobId)
        {
            var job = db.Jobs.Find(jobId);
            if (job == null)
            {
                return HttpNotFound();
            }
            Session["JobId"] = jobId;
            return View(job);
        }

        public ActionResult About()
        {
            TeamInfo teamInfo = new TeamInfo();
            List<TeamInfo> teamInfos = new List<TeamInfo>();
            teamInfos = db.TeamInfoes.ToList();
            List<ApplyForJob> applyForJobs = new List<ApplyForJob>();
            applyForJobs = db.ApplyForJobs.ToList();

            var tuplejoin = new Tuple<List<ApplyForJob>, List<TeamInfo>>(applyForJobs, teamInfos);

           ViewBag.Message = "Your application description page.";

            return View(tuplejoin);
        }

        public ActionResult Contact()
        {
            Contact contact = new Contact();
            List<Contact> contacts = new List<Contact>();
            contacts = db.Contacts.ToList();
            List<ApplyForJob> applyForJobs = new List<ApplyForJob>();
            applyForJobs = db.ApplyForJobs.ToList();

            var tuplejoin = new Tuple<List<ApplyForJob>, List<Contact>>(applyForJobs, contacts);

            return View(tuplejoin);
        }
        /*----------------------------------------------------------------------------------------------------*/
        public ActionResult Search()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Search(string SearchName)
        {
            var ressult = db.Jobs.Where(a => a.JobTittle.Contains(SearchName)
            || a.JobContent.Contains(SearchName)
            || a.category.CategoryName.Contains(SearchName)
            ||a.category.CategoryDescription.Contains(SearchName)
            ) .ToList();


            return View(ressult);
        }
            /*---------------------------------------------------------------------------------*/
            [Authorize]
        public ActionResult Apply()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Apply(string message)
        {
            var UserId = User.Identity.GetUserId();
            var JobId = (int)Session["JobId"]; /* cast to session*/


            var check = db.ApplyForJobs.Where(a => a.JobId == JobId && a.UserId == UserId).ToList();
            if (check.Count < 1)
            {
                ApplyForJob applyJob = new ApplyForJob();
                applyJob.UserId = UserId;
                applyJob.JobId = JobId;
                applyJob.Message = message;
                applyJob.ApplyDate = DateTime.Now;

                db.ApplyForJobs.Add(applyJob);
                db.SaveChanges();
                ViewBag.result = "Apply for Job Successfully";
            }
            else
            {
                ViewBag.result = "You Apply for Job Previoslly";
            }


            return View();
        }
        /*---------------------------------------------------------------------------------*/
        [Authorize]
        public ActionResult GetJobsByUser()
        {

            var userId = User.Identity.GetUserId();
            var jobs = db.ApplyForJobs.Where(a => a.UserId == userId);
            return View(jobs.ToList());
        }
        /*---------------------------------------------------------------------------------*/
        [Authorize]
        public ActionResult DetailsOfJob(int id)
        {
            var job = db.ApplyForJobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }

            return View(job);
        }
        /*---------------------------------------------------------------------------------*/
        [Authorize]
        public ActionResult Edit(int id)
        {
            var job = db.ApplyForJobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job); ;

        }

       
        [HttpPost]
        public ActionResult Edit(ApplyForJob job)
        {
            try
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
            catch
            {
                return View(job);
            }
        }
        //-----------------------------------------------------------------------------------
        public ActionResult Delete(int id)
        {
            var job = db.ApplyForJobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job); ;

        }

        // POST: Role/Delete/5
        [HttpPost]
        public ActionResult Delete(ApplyForJob myjob)
        {

            // TODO: Add delete logic here
            ApplyForJob job = db.ApplyForJobs.Find(myjob.Id);
            db.ApplyForJobs.Remove(job);
            db.SaveChanges();
            return RedirectToAction("GetJobsByUser");
        }
        //----------------------------------------------------------------------------------------
        [Authorize]
        public ActionResult GetJobsByPublisher()
        {

            var userId = User.Identity.GetUserId();
            var jobs = from app in db.ApplyForJobs
                       join job in db.Jobs
                       on app.JobId equals job.id
                       where job.UserId == userId
                       select app;

            var grouped = from j in jobs
                          group j by j.job.JobTittle
                          into gr
                          select new JobsViewModel
                          {
                              JobTitle = gr.Key,
                              Items = gr
        };


            return View(grouped.ToList());
        }




    }
} 
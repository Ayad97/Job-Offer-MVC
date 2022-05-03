using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ASP_IDENTITY.Models;

namespace ASP_IDENTITY.Controllers
{
    public class TeamInfoesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TeamInfoes
        public ActionResult Index()
        {
            return View(db.TeamInfoes.ToList());
        }
        // GET: TeamInfoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeamInfo teamInfo = db.TeamInfoes.Find(id);
            if (teamInfo == null)
            {
                return HttpNotFound();
            }
            return View(teamInfo);
        }

        // GET: TeamInfoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TeamInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TeamInfo teamInfo , HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                string path = Path.Combine(Server.MapPath("~/img/Team"), upload.FileName);
                upload.SaveAs(path);
                teamInfo.TeamImage = upload.FileName;
                db.TeamInfoes.Add(teamInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(teamInfo);
        }

        // GET: TeamInfoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeamInfo teamInfo = db.TeamInfoes.Find(id);
            if (teamInfo == null)
            {
                return HttpNotFound();
            }
            return View(teamInfo);
        }

        // POST: TeamInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( TeamInfo teamInfo , HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                string oldpath = Path.Combine(Server.MapPath("/img/Team"), teamInfo.TeamImage);
                if(upload != null)
                {
                    System.IO.File.Delete(oldpath);
                    string path = Path.Combine(Server.MapPath("~/img/Team"), upload.FileName);
                    upload.SaveAs(path);
                    teamInfo.TeamImage = upload.FileName;   
                    
                }
                db.Entry(teamInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(teamInfo);
        }

        // GET: TeamInfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeamInfo teamInfo = db.TeamInfoes.Find(id);
            if (teamInfo == null)
            {
                return HttpNotFound();
            }
            return View(teamInfo);
        }

        // POST: TeamInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TeamInfo teamInfo = db.TeamInfoes.Find(id);
            db.TeamInfoes.Remove(teamInfo);
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

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ASP_IDENTITY.Models;
using System.IO;
using Microsoft.AspNet.Identity;

namespace ASP_IDENTITY.Controllers
{
    public class TestemonialsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Testemonials
        public ActionResult Index()
        {
            return View(db.Testemonials.ToList());
        }

        // GET: Testemonials/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Testemonials testemonials = db.Testemonials.Find(id);
            if (testemonials == null)
            {
                return HttpNotFound();
            }
            return View(testemonials);
        }

        // GET: Testemonials/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: Testemonials/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Testemonials testemonials, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                string path = Path.Combine(Server.MapPath("~/Testphoto"), upload.FileName);
                upload.SaveAs(path);
                testemonials.image = upload.FileName;
                testemonials.UserId = User.Identity.GetUserId();
               
                db.Testemonials.Add(testemonials);
                db.SaveChanges();
                ViewBag.message = testemonials;
                return RedirectToAction("Index");
            }
            
            return View(testemonials);
        }

        // GET: Testemonials/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Testemonials testemonials = db.Testemonials.Find(id);
            if (testemonials == null)
            {
                return HttpNotFound();
            }
            return View(testemonials);
        }

        // POST: Testemonials/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Testemonials testemonials, HttpPostedFileBase upload)
        {
            
            if (ModelState.IsValid)
            {
                string oldPath = Path.Combine(Server.MapPath("~/Testphoto"), testemonials.image);
                if (upload != null)
                {
                    System.IO.File.Delete(oldPath);
                    string path = Path.Combine(Server.MapPath("~/Testphoto"), upload.FileName);
                    upload.SaveAs(path);
                    testemonials.image = upload.FileName;

                }

                db.Entry(testemonials).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(testemonials);
        }

        // GET: Testemonials/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Testemonials testemonials = db.Testemonials.Find(id);
            if (testemonials == null)
            {
                return HttpNotFound();
            }
            return View(testemonials);
        }

        // POST: Testemonials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Testemonials testemonials = db.Testemonials.Find(id);
            db.Testemonials.Remove(testemonials);
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

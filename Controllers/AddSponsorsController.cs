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
    public class AddSponsorsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AddSponsors
        public ActionResult Index()
        {
            return View(db.AddSponsors.ToList());
        }

        // GET: AddSponsors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddSponsor addSponsor = db.AddSponsors.Find(id);
            if (addSponsor == null)
            {
                return HttpNotFound();
            }
            return View(addSponsor);
        }

        // GET: AddSponsors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AddSponsors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AddSponsor addSponsor, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                string path = Path.Combine(Server.MapPath("~/Testphoto"), upload.FileName);
                upload.SaveAs(path);
                addSponsor.sponsorImage = upload.FileName;

                
                db.AddSponsors.Add(addSponsor);
                db.SaveChanges();
                ViewBag.addsponsor = addSponsor;
                return RedirectToAction("Index");
            }

            return View(addSponsor);
        }

        // GET: AddSponsors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddSponsor addSponsor = db.AddSponsors.Find(id);
            if (addSponsor == null)
            {
                return HttpNotFound();
            }
            return View(addSponsor);
        }

        // POST: AddSponsors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AddSponsor addSponsor , HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                string oldPath = Path.Combine(Server.MapPath("~/Testphoto"), addSponsor.sponsorImage);
                if (upload != null)
                {
                    System.IO.File.Delete(oldPath);
                    string path = Path.Combine(Server.MapPath("~/Testphoto"), upload.FileName);
                    upload.SaveAs(path);
                    addSponsor.sponsorImage = upload.FileName;

                }
                db.Entry(addSponsor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(addSponsor);
        }

        // GET: AddSponsors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddSponsor addSponsor = db.AddSponsors.Find(id);
            if (addSponsor == null)
            {
                return HttpNotFound();
            }
            return View(addSponsor);
        }

        // POST: AddSponsors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AddSponsor addSponsor = db.AddSponsors.Find(id);
            db.AddSponsors.Remove(addSponsor);
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

using ASP_IDENTITY.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP_IDENTITY.Controllers
{
    [Authorize (Roles ="Admins")]
    public class RoleController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
      
        // GET: Role
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View(db.Roles.ToList());
        }

        // GET: Role/Details/5
        public ActionResult Details(string id)
        {
            
            var role = db.Roles.Find(id);
            if(role == null)
            {
                return HttpNotFound();
            }
            return View(role); ;
        }

        // GET: Role/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Role/Create
        [HttpPost]
        public ActionResult Create(IdentityRole role)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Roles.Add(role);
                    db.SaveChanges();
                    ViewBag.reg = role;
                    return RedirectToAction("index");
                }

                return View(role);
            }
            catch
            {
                return View(role);
            }
        }

        // GET: Role/Edit/5
        public ActionResult Edit(string id)
        {
            var role = db.Roles.Find(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role); ;
           
        }

        // POST: Role/Edit/5
        [HttpPost]
        public ActionResult Edit(IdentityRole role)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(role).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(role);
            }
            catch
            {
                return View(role);
            }
        }

        // GET: Role/Delete/5
        public ActionResult Delete(string id)
        {
            var role = db.Roles.Find(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role); ;
            
        }

        // POST: Role/Delete/5
        [HttpPost]
        public ActionResult Delete(IdentityRole myRole)
        {
           
                // TODO: Add delete logic here
                IdentityRole role = db.Roles.Find(myRole.Id);
                db.Roles.Remove(role);
                db.SaveChanges();
                return RedirectToAction("Index");
        }
       
    }
}

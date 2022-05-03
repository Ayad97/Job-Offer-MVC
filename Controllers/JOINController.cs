using ASP_IDENTITY.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ASP_IDENTITY.Controllers
{
    public class JOINController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        Category ct = new Category();
        Testemonials ts = new Testemonials();
        ApplicationUser user = new ApplicationUser();
        Job job = new Job();
        Article article = new Article();

        // GET: JOIN
        public ActionResult Index()
        {
            
            
            List<Category> categories = new List<Category>();
            //categories.Add(new Category() {CategoryName = "kkk" });
            categories = db.Categories.ToList();

            List<Testemonials> testemonial = new List<Testemonials>();
            testemonial = db.Testemonials.ToList();

            List<AddSponsor> addSponsors = new List<AddSponsor>();
            addSponsors = db.AddSponsors.ToList();
            List<Article> articles = new List<Article>();
            articles = db.Articles.ToList();
            
            //testemonial.Add(new Testemonials() {message="sfg3g"});

            //jointuple jointuple = new jointuple();
            //jointuple.categories = categories;
            //jointuple.testemonials = testemonials;

            var tuplejoin = new Tuple<List< Category >, List < Testemonials >,List<AddSponsor>,List<Article>> (categories, testemonial,addSponsors,articles);


            return View(tuplejoin);
        }
        
    }
}
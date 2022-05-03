using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ASP_IDENTITY.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        
        public string UserType { get; set; }
        public string User_Id { get; set; }
        
        public virtual ICollection<Job> Jobs { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
        public virtual ICollection<Contact> Contacts { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }


        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<ASP_IDENTITY.Models.Category> Categories { get; set; }

        public System.Data.Entity.DbSet<ASP_IDENTITY.Models.Job> Jobs { get; set; }

        public System.Data.Entity.DbSet<ASP_IDENTITY.Models.ApplyForJob> ApplyForJobs { get; set; }

        public System.Data.Entity.DbSet<ASP_IDENTITY.Models.Testemonials> Testemonials { get; set; }

        public System.Data.Entity.DbSet<ASP_IDENTITY.Models.jointuple> jointuples { get; set; }

        public System.Data.Entity.DbSet<ASP_IDENTITY.Models.AddSponsor> AddSponsors { get; set; }
        public System.Data.Entity.DbSet<ASP_IDENTITY.Models.Blogs> Blogs { get; set; }
        

        public System.Data.Entity.DbSet<ASP_IDENTITY.Models.Article> Articles { get; set; }

        public System.Data.Entity.DbSet<ASP_IDENTITY.Models.TeamInfo> TeamInfoes { get; set; }

        public System.Data.Entity.DbSet<ASP_IDENTITY.Models.Contact> Contacts { get; set; }
    }
}
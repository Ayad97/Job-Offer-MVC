using ASP_IDENTITY.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ASP_IDENTITY.Startup))]
namespace ASP_IDENTITY
{
    public partial class Startup
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRoles();
            CreateUser();
        }
        public void CreateUser()
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

            var user = new ApplicationUser();
            user.Email = "mahmoudayad97@outlook.com";
            user.UserName = "MahmoudAyad";
            var check = userManager.Create(user, "a123A@@");
            if (check.Succeeded)
            {
                userManager.AddToRole(user.Id, "Admins");
            }


        }
        public void CreateRoles()
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            IdentityRole role; 
            if (!roleManager.RoleExists("Admins"))
            {
                role = new IdentityRole();
                role.Name = "Admins";
                roleManager.Create(role);
            }
            if (!roleManager.RoleExists("Author"))
            {
                role = new IdentityRole();
                role.Name = "Author";
                roleManager.Create(role);
            }
            if (!roleManager.RoleExists("Readers"))
            {
                role = new IdentityRole();
                role.Name = "Readers";
                roleManager.Create(role);
            }

            

        }
    }
}

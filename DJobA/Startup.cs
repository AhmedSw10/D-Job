using hhhhh.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(hhhhh.Startup))]
namespace hhhhh
{
    public partial class Startup
    {
        ApplicationDbContext DB = new ApplicationDbContext();

        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreatRoleUser();
        }
        public void CreatRoleUser()
        {
            var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(DB));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(DB));
            IdentityRole Role = new IdentityRole();
            if (!RoleManager.RoleExists("Admins"))
            {
                Role.Name = "Admins";
                RoleManager.Create(Role);
                ApplicationUser User = new ApplicationUser();
                User.UserName = "Ahmed";
                User.Email = "Ahmed@Ahmed.com";
                var check = UserManager.Create(User, "Aa@123");
                if (check.Succeeded)
                {
                    UserManager.AddToRole(User.Id, "Admins");
                }
            }
        }
    }
}

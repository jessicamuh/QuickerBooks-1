using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using QuickerBooksApp.Models;

[assembly: OwinStartupAttribute(typeof(QuickerBooksApp.Startup))]
namespace QuickerBooksApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
           ConfigureAuth(app);
           createRolesandUsers();
        }

        //Create default User roles and Admin user for login   
        private void createRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            //Create Admin Role and default Admin User    
            if (!roleManager.RoleExists("Administrator"))
            {
                // create Admin   
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Administrator";
                roleManager.Create(role);

                //Here we create a Admin super user who will maintain the website                  

                var user = new ApplicationUser();
                user.UserName = "admin";
                user.Email = "quickerbooks123@gmail.com";
                string userPWD = "Password123!";

                var checkUser = UserManager.Create(user, userPWD);

                //Add default User to Role Admin   
                if (checkUser.Succeeded)
                {
                    var result = UserManager.AddToRole(user.Id, "Administrator");
                }
            }

            //Create Manager role    
            if (!roleManager.RoleExists("Manager"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Manager";
                roleManager.Create(role);

                var user1 = new ApplicationUser();
                user1.UserName = "manager";
                user1.Email = "manager@qb.com";
                string user1PWD = "Password123!";

                var checkUser1 = UserManager.Create(user1, user1PWD);

                //Add default User to Role Admin   
                if (checkUser1.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user1.Id, "Manager");
                }
            }

            //Create regular user role    
            if (!roleManager.RoleExists("User"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "User";
                roleManager.Create(role);

                var user2 = new ApplicationUser();
                user2.UserName = "accountant";
                user2.Email = "accountant@qb.com";
                string user2PWD = "Password123!";

                var checkUser2 = UserManager.Create(user2, user2PWD);

                //Add default User to Role User 
                if (checkUser2.Succeeded)
                {
                    var result2 = UserManager.AddToRole(user2.Id, "User");
                }
            }

        }



    }
}

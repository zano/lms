namespace LMS.Migrations
{
    using LMS.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LMS.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(LMS.Models.ApplicationDbContext context)
        {

            context.Groups.AddOrUpdate(g => g.Name,
                    new Group { Name = ".NET gk" },
                    new Group { Name = ".NET fk" },
                    new Group { Name = "Java gk" },
                    new Group { Name = "Java fk" }
                );

            context.SaveChanges();

            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            if (!roleManager.RoleExists("admin"))
            {
                var role = new IdentityRole("admin");
                roleManager.Create(role);
            }
            context.SaveChanges();

            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);

            foreach (var uname in new[] { "teacher", "student" })
            {
                for (int i = 0; i <= 5; i++)
                {
                    var userName = uname + i + "@lms4.se";
                    if (!context.Users.Any(u => u.UserName == userName))
                    {
                        var user = new ApplicationUser { UserName = userName, Email = userName };
                        userManager.Create(user, "foobar");
                        if (userName.StartsWith("t")) userManager.AddToRole(user.Id, "admin");

                        if (userName.StartsWith("s")) user.Group = context.Groups.First(); 
                    }
                }
            }
            context.SaveChanges();


        }
    }
}

namespace ValueChain.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ValueChain.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<ValueChain.Models.ValueChainDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ValueChain.Models.ValueChainDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Admin" };

                manager.Create(role);
            }
            if (!context.Roles.Any(r => r.Name == "Member"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Member" };

                manager.Create(role);
            }

            if (!context.Users.Any(u => u.UserName == "info.valuechain@gmail.com"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "info.valuechain@gmail.com", Email = "info.valuechain@gmail.com", EmailConfirmed = true };

                manager.Create(user, "admin12345");
                manager.AddToRole(user.Id, "Admin");
            }
        }
    }
}

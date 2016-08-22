namespace CashLady.Identity.Migrations
{
    using Infrastructure;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CashLady.Identity.Infrastructure.ApplicationDbContext>
    {
        public UserManager<ApplicationUser> UserManager { get; private set; }

        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CashLady.Identity.Infrastructure.ApplicationDbContext context)
        {
            ApplicationDbContext t = new ApplicationDbContext();
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(t));
            
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
          //  var t = UserManager.cre
    }
    }
}

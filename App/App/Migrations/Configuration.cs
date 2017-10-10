namespace App.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<App.Models.MultiTenantContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "App.Models.MultiTenantContext";
        }

        protected override void Seed(App.Models.MultiTenantContext context)
        {
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
            var tenants = new List<Tenant> {
                new Tenant()
                {
                    Name="SVCC",
                    DomainName="www.siliconvalley-codecamp.com",
                    Id=1,
                    Default=true
                },
                new Tenant()
                {
                    Name="ANGU",
                    DomainName="angularu.com",
                    Id=3,
                    Default=false
                }
            };

            tenants.ForEach(p => context.Tenants.Add(p));
            context.SaveChanges();
        }
    }
}

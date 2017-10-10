using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Models
{
    [DbConfigurationType(typeof(DataConfiguration))]

    public class MultiTenantContext : DbContext
    {
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<Speaker> Speakers { get; set; }
        public DbSet<Session> Sessions { get; set; }

    }

    public class DataConfiguration : DbConfiguration
    {
        public DataConfiguration()
        {
            SetDatabaseInitializer(new MultiTenantContextInitializer());
        }
    }

    public class MultiTenantContextInitializer
        : CreateDatabaseIfNotExists<MultiTenantContext>
    {
        protected override void Seed(MultiTenantContext context)
        {
            
        }
    }
}

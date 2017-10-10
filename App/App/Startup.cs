using App.Models;
using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
[assembly: OwinStartup(typeof(App.Startup))]

namespace App
{
    class Startup
    {
        private Tenant GetTenantBasedOnUrl(string urlHost)
        {
            if (string.IsNullOrEmpty(urlHost))
            {
                throw new AccessViolationException("urlHost must be specified");
            }
            Tenant tenant;
            using(var context=new MultiTenantContext())
            {
                DbSet<Tenant> tenants = context.Tenants;
                tenant = tenants.FirstOrDefault(a => a.DomainName.ToLower().Equals(urlHost)) ??
                tenants.FirstOrDefault(a => a.Default);
                if (tenant == null)
                {
                    throw new ApplicationException("tenant not found based on url,no default found");
                }
            }
            return tenant;
        }
        public void Configuration(IAppBuilder app)
        {
            app.Use(async (ctx, next) =>
            {
                Tenant tenant = GetTenantBasedOnUrl(ctx.Request.Uri.Host);
                if (tenant == null)
                {
                    throw new ApplicationException("tenant not found");
                }
                ctx.Environment.Add("MultiTenant", tenant);
                await next();
            });
        }
    }
}

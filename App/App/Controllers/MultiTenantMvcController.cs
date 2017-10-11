using App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using System.Web;

namespace App.Controllers
{
    public class MultiTenantMvcController:Controller
    {
        public Tenant Tenant
        {
            get
            {
                object multiTenant;
                if(!Request.GetOwinContext().Environment.TryGetValue("MultiTenant",out multiTenant))
                {
                    throw new ApplicationException("could not find Tenant");
                }
                return (Tenant)multiTenant;
            }
        }
    }
}

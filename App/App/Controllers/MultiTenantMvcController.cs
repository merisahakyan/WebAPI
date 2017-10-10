using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace App.Controllers
{
    class MultiTenantMvcController:Controller
    {
        public TenantController Tenant
        {
            get
            {
                object multiTenant;
                if(!Request.GetOwinContext().)
            }
        }
    }
}

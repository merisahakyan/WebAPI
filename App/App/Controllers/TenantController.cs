using App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.Controllers
{
    public class TenantController : Controller
    {
        public ActionResult Index()
        {
            using (var context = new MultiTenantContext())
            {
                return View(context.Tenants.ToList());
            }


        }


    }
}
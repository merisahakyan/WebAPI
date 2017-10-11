using App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.Controllers
{
    public class SpeakerController : MultiTenantMvcController
    {
        public ActionResult Index()
        {
            return View("Index",Tenant);
        }
    }
}
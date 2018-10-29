using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PatientDemographics.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult PatientInfo()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}

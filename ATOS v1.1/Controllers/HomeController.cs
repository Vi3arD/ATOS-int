using ATOS_v1._1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATOS_v1._1.Managers;

namespace ATOS_v1._1.Controllers
{
    public class HomeController : Controller
    {

        [Authorize(Roles = "admin, user")]
        public ActionResult SuccessAction()
        {
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
   
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
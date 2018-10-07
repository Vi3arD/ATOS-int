using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATOS_v1._1.Models;
using ATOS_v1._1.Managers;

namespace ATOS_v1._1.Controllers
{
    public class AlertController : Controller
    {
        private RoomContext db = new RoomContext();

        [Authorize]
        public ActionResult List()
        {
            var listAlert = db.Alerts.Where(a => a.Status != 0 && a.NameUser == User.Identity.Name).ToList();
            return PartialView(listAlert);
        }

        [HttpPost]
        public ActionResult Viewed(int id)
        {
            db.Alerts.Remove(db.Alerts.Find(id));
            db.SaveChanges();
            return RedirectToAction("List");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

	}
}
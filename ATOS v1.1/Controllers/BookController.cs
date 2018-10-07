using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ATOS_v1._1.Models;
using ATOS_v1._1.Managers;

namespace ATOS_v1._1.Controllers
{
    public class BookController : Controller
    {
        private RoomContext db = new RoomContext();

        [Authorize]
        public ActionResult Create(int id)
        {
            ViewBag.IdRoom = id;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdBook,IdRoom,Description,DateStart,DateEnd,Status")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Books.Add(book);
                db.SaveChanges();
                AlertManager.CreateAlertAfterCreateBook(book, User.Identity.Name);
                return RedirectToAction("Details", "Room", new {id = book.IdRoom});
            }

            return View(book);
        }

        [Authorize(Roles = "admin")]
        public ActionResult List()
        {
            var books = db.Books.Where(b => b.Status == 0).ToList();
            return PartialView(books);
        }

        [HttpPost]
        public ActionResult List(int t = 0)
        {
            var books = db.Books.Where(b => b.Status == 0).ToList();
            return PartialView(books);
        }

        [HttpPost]
        public ActionResult Denide(int id)
        {
            if(BookManager.DenideBookRoom(id))
            {
                return RedirectToAction("List");
            }
            else
            {
                return new HttpStatusCodeResult(404);
            }
        }

        [HttpPost]
        public ActionResult Accept(int id)
        {
            if (BookManager.AcceptBookRoom(id))
            {
                return RedirectToAction("List");
            }
            else
            {
                return new HttpStatusCodeResult(404);
            }
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

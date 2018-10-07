using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ATOS_v1._1.Models;

namespace ATOS_v1._1.Managers
{
    public class AlertManager
    {
        public static void CreateAlertAfterCreateBook(Book book, string userName)
        {
            using (RoomContext db = new RoomContext())
            {
                var getBook = db.Books.FirstOrDefault(b => b.IdRoom == book.IdRoom &&
                                                   b.Status == 0 &&
                                                   b.DateStart == book.DateStart &&
                                                   b.DateEnd == book.DateEnd);
                db.Alerts.Add(new Alert
                {
                    IdBook = getBook.IdBook,
                    NameUser = userName,
                    Status = 0,
                    Name = book.Description
                });
                db.SaveChanges();
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ATOS_v1._1.Models;

namespace ATOS_v1._1.Managers
{
    public class BookManager
    {
        public static Dictionary<int, Book> GetTheFirstBookForRoom ()
        {
            Dictionary<int, Book> bookDictionary = new Dictionary<int, Book>();
            var today = DateTime.Today;
            using (RoomContext db = new RoomContext())
            {
                foreach (var r in db.Rooms.ToList())
                {
                    var firstBooking = db.Books.Where(b => b.Status == 1 && b.IdRoom == r.Id
                       && b.DateStart >= today
                        ).OrderBy(b => b.DateStart).FirstOrDefault();
                    bookDictionary.Add(r.Id, firstBooking);
                }
                return bookDictionary;
            }
        }

        public static void DeleteBooksToDeleteRoom (int idRoom)
        {
            using (RoomContext db = new RoomContext())
            {
                var list_books = db.Books.Where(b => b.IdRoom == idRoom).ToList();
                foreach(var item in list_books)
                {
                    Book book = db.Books.Find(item.IdBook);
                    if (book != null)
                    {
                        db.Books.Remove(book);
                    }
                }
            }
        }

        public static bool DenideBookRoom (int id)
        {
            using (RoomContext db = new RoomContext())
            {
                var denideBooks = db.Books.FirstOrDefault(b => b.IdBook == id);
                if (denideBooks != null)
                {
                    db.Books.Remove(denideBooks);

                    var denideAlert = db.Alerts.FirstOrDefault(a => a.IdBook == id);
                    if (denideAlert != null)
                    {
                        denideAlert.Status = -1;
                        db.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
        }

        public static bool AcceptBookRoom(int id)
        {
            using (RoomContext db = new RoomContext())
            {
                var acceptBooks = db.Books.FirstOrDefault(b => b.IdBook == id);
                if (acceptBooks != null)
                {
                    acceptBooks.Status = 1;

                    var acceptAlert = db.Alerts.FirstOrDefault(a => a.IdBook == id);
                    if (acceptAlert != null)
                    {
                        acceptAlert.Status = 1;
                        db.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
        }

    }
}
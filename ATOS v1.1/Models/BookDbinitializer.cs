using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ATOS_v1._1.Models
{
    public class BookDbinitializer : DropCreateDatabaseAlways<RoomContext>
    {
        //protected override void Seed(BookContext db)
        //{
        //    db.Books.Add(new Book
        //    {
        //        IdRoom = 1,
        //        Description = "The start book.",
        //        DateStart = DateTime.Now,
        //        DateEnd = DateTime.Now,
        //        Status = 0
        //    });

        //    base.Seed(db);
        //}
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ATOS_v1._1.Models
{
    public class RoomDbinitializer : DropCreateDatabaseAlways<RoomContext>
    {
        protected override void Seed(RoomContext db)
        {
            db.Rooms.Add(new Room { 
                                    Name = "Room Zero",
                                    CountChair = 13,
                                    IsProjector = true,
                                    IsBlackboard = false,
                                    Description = "The start room."});

            base.Seed(db);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ATOS_v1._1.Models
{
    public class UserDbInitializer : DropCreateDatabaseAlways<UserContext>
    {
        protected override void Seed(UserContext db)
        {
            Role admin = new Role { Id = 1, Name = "admin" };
            Role user = new Role { Id = 2, Name = "user" };
            db.Roles.Add(admin);
            db.Roles.Add(user);
            db.Users.Add(new User
            {
                Name = "admin",
                Password = "123123",
                FullName = "admin",
                RoleId = 1
            });
            db.Users.Add(new User
            {
                Name = "user",
                Password = "123123",
                FullName = "user",
                RoleId = 2
            });
            base.Seed(db);
        }
    }
}
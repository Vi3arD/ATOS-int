using ATOS_v1._1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace ATOS_v1._1.Providers
{
    public class CustomRoleProvider : RoleProvider
    {
        //UserContext udb = new UserContext();

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            string[] roles = new string[] { };
            using (UserContext udb = new UserContext())
            {
                User user = udb.Users.FirstOrDefault(u => u.Name == username);
                if (user != null)
                {
                    Role userRole = udb.Roles.Find(user.RoleId);
                    if (userRole != null)
                    {
                        roles = new string[] { user.Role.Name };
                    }
                }
                return roles;
            }
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            bool finalyResult = false;

            using (UserContext udb = new UserContext())
            {
                User user = udb.Users.FirstOrDefault(u => u.Name == username);

                if (user != null)
                {
                    Role userRole = udb.Roles.Find(user.RoleId);
                    if (userRole != null && userRole.Name == roleName)
                    {
                        finalyResult = true;
                    }
                }
            }
            return finalyResult;
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}
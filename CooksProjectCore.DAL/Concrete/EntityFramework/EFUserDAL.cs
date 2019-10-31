using CooksProjectCore.Core.DAL.EntityFramework;
using CooksProjectCore.Core.Entities.Concrete;
using CooksProjectCore.DAL.Asbtract;
using CooksProjectCore.DAL.Concrete.EntityFramework.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooksProjectCore.DAL.Concrete.EntityFramework
{
    public class EFUserDAL : EFEntityRepositoryBase<User, CooksContext>, IUserDAL
    {
        public List<Role> GetRoles(User user)
        {
            using (var db = new CooksContext())
            {
                var userRoles = from roles in db.Roles
                                join user_roles in db.UserRoles on roles.ID equals user_roles.RoleID
                                where user_roles.UserID == user.ID
                                select new Role { ID=roles.ID, RoleName=roles.RoleName};
                return userRoles.ToList();
            }
        }
    }
}

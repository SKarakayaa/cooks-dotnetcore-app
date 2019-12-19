using CooksProjectCore.Core.DAL.EntityFramework;
using CooksProjectCore.DAL.Asbtract;
using CooksProjectCore.DAL.Concrete.EntityFramework.Context;
using CooksProjectCore.Entities.Concrete;
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

        public void AddSocialMedia(SocialMedia socialMedia)
        {
            using (var db = new CooksContext())
            {
                db.Entry(socialMedia).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                db.SaveChanges();
            }
        }
        public void UpdateSocialMedia(SocialMedia socialMedia)
        {
            using(var db = new CooksContext())
            {
                db.Entry(socialMedia).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
            }
        }
        public SocialMedia SocialMediaOfUser(int userId)
        {
            using (var db = new CooksContext())
            {
                return db.SocialMedias.SingleOrDefault(f => f.UserID == userId);
            }
        }
        public void AssignRole(int userId)
        {
            using (var db = new CooksContext())
            {
                var user_roles = new UserRole
                {
                    UserID = userId,
                    RoleID = (int)RoleEnum.Default
                };
                db.Entry(user_roles).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                db.SaveChanges();
            }
        }
    }
}

using CooksProjectCore.Core.DAL;
using CooksProjectCore.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CooksProjectCore.DAL.Asbtract
{
    public interface IUserDAL:IEntityRepository<User>
    {
        List<Role> GetRoles(User user);
        void AddSocialMedia(SocialMedia socialMedia);
        void UpdateSocialMedia(SocialMedia socialMedia);
        SocialMedia SocialMediaOfUser(int userId);
        void AssignRole(int userId);
    }
}

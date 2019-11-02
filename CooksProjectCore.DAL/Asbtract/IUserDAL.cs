using CooksProjectCore.Core.DAL;
using CooksProjectCore.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CooksProjectCore.DAL.Asbtract
{
    public interface IUserDAL:IEntityRepository<User>
    {
        List<Role> GetRoles(User user);

        void AddFollow(FollowTable followTable);
        void DeleteFollow(FollowTable followTable);
        List<FollowTable> Followers(int userId);
        List<FollowTable> Follows(int userId);

        void AddSocialMedia(SocialMedia socialMedia);
        void UpdateSocialMedia(SocialMedia socialMedia);
        SocialMedia SocialMediaOfUser(int userId);
    }
}

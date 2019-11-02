using CooksProjectCore.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CooksProjectCore.BLL.Abstract
{
    public interface IUserService
    {
        void Add(User user);
        List<Role> GetRoles(User user);
        User GetUserByMail(string mail);
        User GetUserByID(int userId);
        List<User> GetUsers();
        void AddFollow(FollowTable followTable);
        void DeleteFollow(FollowTable followTable);
        void AddSocialMedia(SocialMedia socialMedia);
        void UpdateSocialMedia(SocialMedia socialMedia);
        SocialMedia GetSocialMedia(int userId);
        List<FollowTable> Follows(int userId);
        List<FollowTable> Followers(int userId);
    }
}

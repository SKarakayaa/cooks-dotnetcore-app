using CooksProjectCore.BLL.Abstract;
using CooksProjectCore.Core.Entities.Concrete;
using CooksProjectCore.DAL.Asbtract;
using System;
using System.Collections.Generic;
using System.Text;

namespace CooksProjectCore.BLL.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDAL _userDAL;
        public UserManager(IUserDAL _userDAL)
        {
            this._userDAL = _userDAL;
        }
        public void Add(User user)
        {
            _userDAL.Add(user);
        }

        public void AddFollow(FollowTable followTable)
        {
            _userDAL.AddFollow(followTable);
        }

        public void AddSocialMedia(SocialMedia socialMedia)
        {
            _userDAL.AddSocialMedia(socialMedia);
        }

        public void DeleteFollow(FollowTable followTable)
        {
            _userDAL.DeleteFollow(followTable);
        }

        public List<Role> GetRoles(User user)
        {
           return _userDAL.GetRoles(user);
        }

        public User GetUserByID(int userId)
        {
            return _userDAL.Get(f => f.ID == userId);
        }

        public User GetUserByMail(string mail)
        {
            return _userDAL.Get(f => f.Email == mail);
        }

        public List<User> GetUsers()
        {
            return _userDAL.GetList();
        }

        public void UpdateSocialMedia(SocialMedia socialMedia)
        {
            _userDAL.UpdateSocialMedia(socialMedia);
        }
        public SocialMedia GetSocialMedia(int userId)
        {
            return _userDAL.SocialMediaOfUser(userId);
        }
        public List<FollowTable> Follows(int userId)
        {
            return _userDAL.Follows(userId);
        }
        public List<FollowTable> Followers(int userId)
        {
            return _userDAL.Followers(userId);
        }
    }
}

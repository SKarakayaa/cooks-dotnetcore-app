using CooksProjectCore.BLL.Abstract;
using CooksProjectCore.Core.Aspects.Caching;
using CooksProjectCore.DAL.Asbtract;
using CooksProjectCore.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CooksProjectCore.BLL.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDAL _userDAL;
        public UserManager(IUserDAL userDAL)
        {
            _userDAL = userDAL;
        }
        [RemoveCacheAspect(pattern:"IUserService.Get",Priority = 1)]
        public void Add(User user)
        {
            _userDAL.Add(user);
        }
        public void Update(User user)
        {
            _userDAL.Update(user);
        }

        public void AddSocialMedia(SocialMedia socialMedia)
        {
            _userDAL.AddSocialMedia(socialMedia);
        }

        public void AssignRole(int userId)
        {
            _userDAL.AssignRole(userId);
        }

        public List<Role> GetRoles(User user)
        {
            return _userDAL.GetRoles(user);
        }

        public User GetUserByID(int userId)
        {
            return _userDAL.Get(x => x.ID == userId,new string[]{ "SocialMedia" });
        }

        public User GetUserByMail(string mail)
        {
            return _userDAL.Get(x => x.Email == mail);
        }
        [CacheAspect(duration:30,Priority = 1)]
        public List<User> GetUsers()
        {
            return _userDAL.GetList();
        }

        public void UpdateSocialMedia(SocialMedia socialMedia)
        {
            _userDAL.UpdateSocialMedia(socialMedia);
        }
    }
}

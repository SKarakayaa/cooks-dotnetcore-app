using CooksProjectCore.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CooksProjectCore.BLL.Abstract
{
    public interface IUserService
    {
        //User
        void Add(User user);
        List<Role> GetRoles(User user);
        User GetUserByMail(string mail);
        User GetUserByID(int userId);
        void Update(User user);
        List<User> GetUsers();
        void AssignRole(int userId);

        //Social Media
        void AddSocialMedia(SocialMedia socialMedia);
        void UpdateSocialMedia(SocialMedia socialMedia);
       
        
    }
}

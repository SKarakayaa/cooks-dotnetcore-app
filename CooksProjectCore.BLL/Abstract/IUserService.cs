using CooksProjectCore.Entities.Concrete;
using CooksProjectCore.Entities.Dto;
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
        UserDTO_ForView GetUserByID(int userId);
        void Update(User user);
        List<UserDTO_ForEntities> GetUsers();
        void AssignRole(int userId);

        //Social Media
        void AddSocialMedia(SocialMedia socialMedia);
        void UpdateSocialMedia(SocialMedia socialMedia);
       
        
    }
}

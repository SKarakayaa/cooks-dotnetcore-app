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

        public List<Role> GetRoles(User user)
        {
           return _userDAL.GetRoles(user);
        }

        public User GetUserByMail(string mail)
        {
            return _userDAL.Get(f => f.Email == mail);
        }
    }
}

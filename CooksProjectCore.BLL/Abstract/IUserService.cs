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
    }
}

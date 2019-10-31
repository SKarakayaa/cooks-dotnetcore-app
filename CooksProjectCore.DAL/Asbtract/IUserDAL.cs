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
    }
}

using CooksProjectCore.Core.Utilities.Results;
using CooksProjectCore.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CooksProjectCore.BLL.Abstract
{
    public interface IUserService
    {
        IDataResult<List<User>> GetUsers();
        IDataResult<List<User>> GetUsers(int memberType);
        IDataResult<User> GetUser(int userId);
        IResult Add(User user);
        IResult Update(User user);
        IResult Delete(User user);
    }
}

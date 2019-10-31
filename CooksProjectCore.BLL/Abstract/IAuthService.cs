using CooksProjectCore.Core.Entities.Concrete;
using CooksProjectCore.Core.Security;
using CooksProjectCore.Core.Utilities.Results;
using CooksProjectCore.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace CooksProjectCore.BLL.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Register(RegisterDTO registerDTO);
        IDataResult<User> Login(LoginDTO loginDTO);
        IResult UserExist(string mail);
        IDataResult<AccessToken> CreateAccessToken(User user);
    }
}

using CooksProjectCore.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CooksProjectCore.Core.Security
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<Role> roles);
    }
}

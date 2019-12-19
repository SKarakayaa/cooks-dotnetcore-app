using CooksProjectCore.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace CooksProjectCore.Entities.Concrete
{ 
    public enum RoleEnum
    {
        Default=1,
        UsersList=2,
        UsersDelete=3,
        Authorizer=4
    }
    public class Role:IEntity
    {
        public int ID{ get; set; }
        public string RoleName{ get; set; }
    }
}

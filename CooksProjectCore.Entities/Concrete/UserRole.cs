using CooksProjectCore.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace CooksProjectCore.Entities.Concrete
{
    public class UserRole:IEntity
    {
        public int ID{ get; set; }
        public int UserID{ get; set; }
        public int RoleID{ get; set; }
    }
}

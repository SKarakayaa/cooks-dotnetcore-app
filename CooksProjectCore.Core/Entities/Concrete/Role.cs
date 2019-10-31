using System;
using System.Collections.Generic;
using System.Text;

namespace CooksProjectCore.Core.Entities.Concrete
{
    public class Role:IEntity
    {
        public int ID{ get; set; }
        public string RoleName{ get; set; }
    }
}

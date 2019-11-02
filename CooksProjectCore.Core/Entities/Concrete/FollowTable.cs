using System;
using System.Collections.Generic;
using System.Text;

namespace CooksProjectCore.Core.Entities.Concrete
{
    public class FollowTable:IEntity
    {
        public int ID{ get; set; }
        public int FollowID{ get; set; }
        public int FollowerID{ get; set; }
    }
}

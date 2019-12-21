using CooksProjectCore.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CooksProjectCore.Entities.Concrete
{
    public class FollowTable:IEntity
    {
        public int ID{ get; set; }
        public int FollowID{ get; set; }
        public int FollowerID{ get; set; }

        [ForeignKey("FollowID")]
        public virtual User FollowUser{ get; set; }
        [ForeignKey("FollowerID")]
        public virtual User FollowerUser{ get; set; }
    }
}

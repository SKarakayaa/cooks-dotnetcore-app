using CooksProjectCore.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace CooksProjectCore.Entities.Dto
{
    public class FollowTableDTO:IDto
    {
        public int ID{ get; set; }
        public int FollowID{ get; set; }
        public UserDTO_ForEntities FollowUser{ get; set; }
    }
}

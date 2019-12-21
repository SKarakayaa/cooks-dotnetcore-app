using CooksProjectCore.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace CooksProjectCore.Entities.Dto
{
    public class FollowerTableDTO:IDto
    {
        public int ID { get; set; }
        public int FollowerID { get; set; }
        public UserDTO_ForEntities FollowerUser { get; set; }
    }
}

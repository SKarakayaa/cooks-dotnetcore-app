using CooksProjectCore.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace CooksProjectCore.Entities.Dto
{
    public class UserDTO_ForEntities:IDto
    {
        public int ID{ get; set; }
        public string Name{ get; set; }
        public string Surname{ get; set; }
    }
}

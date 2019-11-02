using CooksProjectCore.Core.Entities;
using CooksProjectCore.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CooksProjectCore.Entities.Dto
{
    public class UserDTO:IDto
    {
        public string Name{ get; set; }
        public string Surname{ get; set; }
        public string Email{ get; set; }
        public DateTime AddedDate{ get; set; }
        public string Job{ get; set; }
        public SocialMedia SocialMedia{ get; set; }
    }
}

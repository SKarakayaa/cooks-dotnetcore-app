using CooksProjectCore.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace CooksProjectCore.Entities.Dto
{
    public class LoginDTO:IDto
    {
        public string Email{ get; set; }
        public string Password{ get; set; }
    }
}

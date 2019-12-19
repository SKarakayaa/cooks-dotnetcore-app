using CooksProjectCore.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace CooksProjectCore.Entities.Dto
{
    public class RegisterDTO:IDto
    {
        public string Name{ get; set; }
        public string Surname{ get; set; }
        public string Email{ get; set; }
        public string Password{ get; set; }
        public string Job { get; set; }
    }
}

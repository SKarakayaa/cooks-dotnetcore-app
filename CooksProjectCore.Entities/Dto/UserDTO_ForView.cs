using CooksProjectCore.Entities.Abstract;
using CooksProjectCore.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CooksProjectCore.Entities.Dto
{
    public class UserDTO_ForView:IDto
    {
        public int ID{ get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public DateTime AddedDate { get; set; }
        public string Job { get; set; }
        public SocialMedia SocialMedia { get; set; }
    }
}

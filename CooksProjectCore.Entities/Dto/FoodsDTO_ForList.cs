using CooksProjectCore.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace CooksProjectCore.Entities.Dto
{
    public class FoodsDTO_ForList:IDto
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public int UserID { get; set; }
        public string Recipe { get; set; }
        public string ImageUrl { get; set; }
        public DateTime AddedDate { get; set; }
        public int TotalLikes { get; set; }
        public int TotalComments { get; set; }
        public UserDTO_ForEntities User { get; set; }
    }
}

using CooksProjectCore.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace CooksProjectCore.Entities.Dto
{
    public class FoodDTO_ForSave:IDto
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public int UserID { get; set; }
        public string Recipe { get; set; }
        public string ImageUrl { get; set; }
        public int FoodType { get; set; }
        public DateTime AddedDate { get; set; }
        public Nullable<DateTime> ModifiedDate { get; set; }
        public Nullable<int> TotalLikes { get; set; }
        public Nullable<int> TotalComments { get; set; }
    }
}

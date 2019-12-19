using CooksProjectCore.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CooksProjectCore.Entities.Concrete
{
    public class Food:IEntity
    {
        public Food()
        {
            this.Comments = new List<Comment>();
            this.FoodEquipments = new List<FoodEquipment>();
        }
        public Guid ID{ get; set; }
        public string Name{ get; set; }
        public int UserID{ get; set; }
        public string Recipe{ get; set; }
        public string ImageUrl{ get; set; }
        public int FoodType{ get; set; }
        public DateTime AddedDate{ get; set; }
        public Nullable<DateTime> ModifiedDate{ get; set; }
        public Nullable<int> TotalLikes{ get; set; }
        public Nullable<int> TotalComments{ get; set; }

        [ForeignKey("UserID")]
        public virtual User User{ get; set; }

        public IList<Comment> Comments { get; set; }
        public IList<FoodEquipment> FoodEquipments { get; set; }
    }
}

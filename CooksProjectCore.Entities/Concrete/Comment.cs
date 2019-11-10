using CooksProjectCore.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CooksProjectCore.Entities.Concrete
{
    public class Comment:IEntity
    {
        public Guid ID{ get; set; }
        public Guid FoodID{ get; set; }
        public int UserID{ get; set; }
        public string Text{ get; set; }
        public DateTime AddedDate{ get; set; }
    }
}

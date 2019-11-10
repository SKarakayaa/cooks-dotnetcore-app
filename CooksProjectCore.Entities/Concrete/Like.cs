using CooksProjectCore.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CooksProjectCore.Entities.Concrete
{
    public class Like:IEntity
    {
        public int ID{ get; set; }
        public Guid FoodID{ get; set; }
        public int UserID{ get; set; }
    }
}

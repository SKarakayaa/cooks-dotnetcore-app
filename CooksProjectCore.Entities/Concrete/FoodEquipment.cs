using CooksProjectCore.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CooksProjectCore.Entities.Concrete
{
    public class FoodEquipment:IEntity
    {
        [Key]
        public int ID{ get; set; }
        public Guid FoodID { get; set; }
        public string EquipmentName{ get; set; }
    }
}

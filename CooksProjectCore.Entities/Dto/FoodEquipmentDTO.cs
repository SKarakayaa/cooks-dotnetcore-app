using CooksProjectCore.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace CooksProjectCore.Entities.Dto
{
    public class FoodEquipmentDTO:IDto
    {
        public int ID{ get; set; }
        public string EquipmentName{ get; set; }
    }
}

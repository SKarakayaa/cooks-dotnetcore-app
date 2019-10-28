﻿using CooksProjectCore.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CooksProjectCore.Entities.Concrete
{
    public class User:IEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname{ get; set; }
        public string Email{ get; set; }
        public DateTime AddedDate{ get; set; }
        public Nullable<DateTime> ModifiedDate{ get; set; }
        public string Job{ get; set; }
        public int MemberType { get; set; }
    }
}

using CooksProjectCore.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CooksProjectCore.Entities.Concrete
{
    public class CommentReply:IEntity
    {
        public Guid ID { get; set; }
        public Guid CommentID{ get; set; }
        public int UserID{ get; set; }
        public string Text{ get; set; }
        public DateTime AddedDate{ get; set; }
    }
}

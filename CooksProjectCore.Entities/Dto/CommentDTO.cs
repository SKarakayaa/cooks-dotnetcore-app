using CooksProjectCore.Core.Entities;
using CooksProjectCore.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CooksProjectCore.Entities.Dto
{
    public class CommentDTO:IDto
    {
        public Comment Comments{ get; set; }
        public List<CommentReply> CommentReplies{ get; set; }
    }
}

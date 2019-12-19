using CooksProjectCore.Entities.Abstract;
using CooksProjectCore.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CooksProjectCore.Entities.Dto
{
    public class CommentDTO:IDto
    {
        public Guid ID { get; set; }
        public Guid FoodID { get; set; }
        public int UserID { get; set; }
        public string Text { get; set; }
        public DateTime AddedDate { get; set; }
        public UserDTO_ForEntities User { get; set; }
        public List<CommentReplyDTO> CommentReplies{ get; set; }
    }
}

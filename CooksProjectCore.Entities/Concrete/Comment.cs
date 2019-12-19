using CooksProjectCore.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CooksProjectCore.Entities.Concrete
{
    public class Comment:IEntity
    {
        public Comment()
        {
            this.CommentReplies = new List<Comment>();
        }

        public Guid ID{ get; set; }
        public Nullable<Guid> ParentCommentID{ get; set; }
        public Guid FoodID{ get; set; }
        public int UserID{ get; set; }
        public string Text{ get; set; }
        public DateTime AddedDate{ get; set; }

        [ForeignKey("FoodID")]
        public virtual Food Food{ get; set; }
        [ForeignKey("UserID")]
        public virtual User User{ get; set; }
        [ForeignKey("ParentCommentID")]
        public virtual Comment ParentComment{ get; set; }

        public virtual IList<Comment> CommentReplies{ get; set; }
    }
}

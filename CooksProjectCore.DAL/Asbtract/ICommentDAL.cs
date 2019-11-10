using CooksProjectCore.Core.DAL;
using CooksProjectCore.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CooksProjectCore.DAL.Asbtract
{
    public interface ICommentDAL:IEntityRepository<Comment>
    {
        List<CommentReply> GetCommentReplies(Guid commentId);
        void AddCommentReply(CommentReply commentReply);
        void DeleteCommentReply(Guid replyId);
    }
}

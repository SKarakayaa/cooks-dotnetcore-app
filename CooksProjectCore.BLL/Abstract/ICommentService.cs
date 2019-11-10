using CooksProjectCore.Core.Utilities.Results;
using CooksProjectCore.Entities.Concrete;
using CooksProjectCore.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace CooksProjectCore.BLL.Abstract
{
    public interface ICommentService
    {
        IDataResult<List<CommentDTO>> GetComments(Guid foodId);
        IResult AddComment(Comment comment);
        IResult DeleteComment(Guid commentId);

        IResult AddCommentReply(CommentReply commentReply);
        IResult DeleteCommentReply(Guid replyId);
    }
}

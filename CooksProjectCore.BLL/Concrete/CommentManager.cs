using CooksProjectCore.BLL.Abstract;
using CooksProjectCore.Core.Utilities.Results;
using CooksProjectCore.DAL.Asbtract;
using CooksProjectCore.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CooksProjectCore.BLL.Concrete
{
    public class CommentManager : ICommentService
    {
        private readonly ICommentDAL _commentDAL;
        public CommentManager(ICommentDAL commentDAL)
        {
            _commentDAL = commentDAL;
        }
        public IResult AddComment(Comment comment)
        {
            _commentDAL.Add(comment);
            return new SuccessResult();
        }

        public IResult DeleteComment(Guid commentId)
        {
            var comment = _commentDAL.Get(x => x.ID == commentId);
            _commentDAL.Remove(comment);
            return new SuccessResult();
        }
    }
}

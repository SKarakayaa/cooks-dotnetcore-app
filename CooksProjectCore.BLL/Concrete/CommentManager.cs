using CooksProjectCore.BLL.Abstract;
using CooksProjectCore.BLL.Constants;
using CooksProjectCore.Core.Utilities.Results;
using CooksProjectCore.DAL.Asbtract;
using CooksProjectCore.Entities.Concrete;
using CooksProjectCore.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace CooksProjectCore.BLL.Concrete
{
    public class CommentManager : ICommentService
    {
        private ICommentDAL _commentDAL;
        public CommentManager(ICommentDAL _commentDAL)
        {
            this._commentDAL = _commentDAL;
        }

        public IResult AddComment(Comment comment)
        {
            _commentDAL.Add(comment);
            return new SuccessResult(Messages.AddedComment);
        }

        public IResult AddCommentReply(CommentReply commentReply)
        {
            _commentDAL.AddCommentReply(commentReply);
            return new SuccessResult(Messages.AddedComment);
        }

        public IResult DeleteComment(Guid commentId)
        {
            var comment = _commentDAL.Get(f => f.ID == commentId);
            if (comment != null)
            {
                _commentDAL.Remove(comment);
                return new SuccessResult(Messages.DeleteComment);
            }
            return new ErrorResult();
        }

        public IResult DeleteCommentReply(Guid replyId)
        {
            _commentDAL.DeleteCommentReply(replyId);
            return new SuccessResult(Messages.DeleteComment);
        }

        public IDataResult<List<CommentDTO>> GetComments(Guid foodId)
        {
            var comments = _commentDAL.GetList(f => f.FoodID == foodId);
            List<CommentDTO> commentDTOs = new List<CommentDTO>();
            foreach (var comment in comments)
            {
                var cmtDto = new CommentDTO
                {
                    Comments = comment,
                    CommentReplies = _commentDAL.GetCommentReplies(comment.ID)
                };
                commentDTOs.Add(cmtDto);
            }
            return new SuccessDataResult<List<CommentDTO>>(commentDTOs);
        }
    }
}

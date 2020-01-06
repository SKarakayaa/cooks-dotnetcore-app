using CooksProjectCore.BLL.Abstract;
using CooksProjectCore.BLL.Validation.FluentValidation;
using CooksProjectCore.Core.Aspects.Caching;
using CooksProjectCore.Core.Aspects.Validation;
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
        [AspectValidation(typeof(CommentValidation),Priority = 1)]
        [RemoveCacheAspect(pattern:"ICommentService.Get",Priority = 2)]
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
        [CacheAspect(duration:20,Priority = 1)]
        public IDataResult<List<Comment>> GetCommentsByMenu(Guid menuId)
        {
            return new SuccessDataResult<List<Comment>>(_commentDAL.GetList(x => x.FoodID == menuId && x.ParentCommentID == null, new string[] { "CommentReplies","User","CommentReplies.User" }));
        }
    }
}

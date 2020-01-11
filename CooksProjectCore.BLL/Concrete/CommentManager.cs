using AutoMapper;
using CooksProjectCore.BLL.Abstract;
using CooksProjectCore.BLL.Validation.FluentValidation;
using CooksProjectCore.Core.Aspects.Caching;
using CooksProjectCore.Core.Aspects.Logging;
using CooksProjectCore.Core.Aspects.Validation;
using CooksProjectCore.Core.CrossCuttingConcerns.Logging.log4net.Loggers;
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
        private readonly ICommentDAL _commentDAL;
        private readonly IMapper _mapper;
        public CommentManager(ICommentDAL commentDAL,IMapper mapper)
        {
            _commentDAL = commentDAL;
            _mapper = mapper;
        }
        [AspectValidation(typeof(CommentValidation),Priority = 1)]
        [RemoveCacheAspect(pattern:"ICommentService.Get",Priority = 2)]
        [LogAspect(typeof(RequestsFileLogger),Priority = 3)]
        public IResult AddComment(Comment comment)
        {
            _commentDAL.Add(comment);
            return new SuccessResult();
        }
        [RemoveCacheAspect(pattern: "ICommentService.Get", Priority = 1)]
        [LogAspect(typeof(RequestsFileLogger), Priority = 2)]
        public IResult DeleteComment(Guid commentId)
        {
            var comment = _commentDAL.Get(x => x.ID == commentId);
            _commentDAL.Remove(comment);
            return new SuccessResult();
        }
        [CacheAspect(duration:20,Priority = 1)]
        public IDataResult<List<CommentDTO>> GetCommentsByMenu(Guid menuId)
        {
            var comments = _commentDAL.GetList(x => x.FoodID == menuId && x.ParentCommentID == null, new string[] { "CommentReplies", "User", "CommentReplies.User" });
            return new SuccessDataResult<List<CommentDTO>>(_mapper.Map<List<CommentDTO>>(comments));
        }
    }
}

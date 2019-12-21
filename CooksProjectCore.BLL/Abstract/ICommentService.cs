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
        IResult AddComment(Comment comment);
        IResult DeleteComment(Guid commentId);
        IDataResult<List<Comment>> GetCommentsByMenu(Guid menuId);
    }
}

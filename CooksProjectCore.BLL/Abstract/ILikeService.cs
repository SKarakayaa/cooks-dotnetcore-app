using CooksProjectCore.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CooksProjectCore.BLL.Abstract
{
    public interface ILikeService
    {
        List<Like> GetLikes(Guid foodId);
        void AddLike(Like like);
        void DeleteLike(Like like);
    }
}

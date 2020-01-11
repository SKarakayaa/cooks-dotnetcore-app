using CooksProjectCore.BLL.Abstract;
using CooksProjectCore.Core.Aspects.Transaction;
using CooksProjectCore.DAL.Asbtract;
using CooksProjectCore.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CooksProjectCore.BLL.Concrete
{
    public class LikeManager : ILikeService
    {
        private readonly ILikeDAL _likeDAL;
        public LikeManager(ILikeDAL likeDAL)
        {
            _likeDAL = likeDAL;
        }
        [TransactionAspect(Priority = 1)]
        public void AddLike(Like like)
        {
            _likeDAL.Add(like);
        }
        [TransactionAspect(Priority = 1)]
        public void DeleteLike(Like like)
        {
            _likeDAL.Add(like);
        }

        public List<Like> GetLikes(Guid foodId)
        {
            return _likeDAL.GetList(x => x.FoodID == foodId);
        }
    }
}

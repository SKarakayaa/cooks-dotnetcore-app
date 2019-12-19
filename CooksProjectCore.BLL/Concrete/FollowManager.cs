using CooksProjectCore.BLL.Abstract;
using CooksProjectCore.DAL.Asbtract;
using CooksProjectCore.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CooksProjectCore.BLL.Concrete
{
    public class FollowManager : IFollowService
    {
        private readonly IFollowDAL _followDAL;
        public FollowManager(IFollowDAL followDAL)
        {
            _followDAL = followDAL;
        }
        public void AddFollow(FollowTable followTable)
        {
            _followDAL.Add(followTable);
        }

        public void DeleteFollow(FollowTable followTable)
        {
            _followDAL.Remove(followTable);
        }

        public List<FollowTable> Followers(int userId)
        {
            return _followDAL.GetList(x => x.FollowID == userId);
        }

        public List<FollowTable> Follows(int userId)
        {
            return _followDAL.GetList(x => x.FollowerID == userId);
        }
    }
}

using CooksProjectCore.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CooksProjectCore.BLL.Abstract
{
    public interface IFollowService
    {
        //Follow and Followers
        void AddFollow(FollowTable followTable);
        void DeleteFollow(FollowTable followTable);
        List<FollowTable> Follows(int userId);
        List<FollowTable> Followers(int userId);
    }
}

using CooksProjectCore.Entities.Concrete;
using CooksProjectCore.Entities.Dto;
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
        List<FollowTableDTO> Follows(int userId);
        List<FollowerTableDTO> Followers(int userId);
    }
}

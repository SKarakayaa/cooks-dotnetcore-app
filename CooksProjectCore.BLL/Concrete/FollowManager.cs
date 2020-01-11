using AutoMapper;
using CooksProjectCore.BLL.Abstract;
using CooksProjectCore.DAL.Asbtract;
using CooksProjectCore.Entities.Concrete;
using CooksProjectCore.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace CooksProjectCore.BLL.Concrete
{
    public class FollowManager : IFollowService
    {
        private readonly IFollowDAL _followDAL;
        private readonly IMapper _mapper;
        public FollowManager(IFollowDAL followDAL,IMapper mapper)
        {
            _followDAL = followDAL;
            _mapper = mapper;
        }
        public void AddFollow(FollowTable followTable)
        {
            _followDAL.Add(followTable);
        }

        public void DeleteFollow(FollowTable followTable)
        {
            _followDAL.Remove(followTable);
        }

        public List<FollowerTableDTO> Followers(int userId)
        {
            var followers = _followDAL.GetList(x => x.FollowID == userId,new string[] { "FollowerUser" });
            return _mapper.Map<List<FollowerTableDTO>>(followers);
        }

        public List<FollowTableDTO> Follows(int userId)
        {
            var follows = _followDAL.GetList(x => x.FollowerID == userId,new string[] { "FollowUser" });
            return _mapper.Map<List<FollowTableDTO>>(follows);
        }
    }
}

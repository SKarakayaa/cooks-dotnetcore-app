using AutoMapper;
using CooksProjectCore.BLL.Abstract;
using CooksProjectCore.Core.Aspects.Caching;
using CooksProjectCore.Core.Aspects.Logging;
using CooksProjectCore.Core.CrossCuttingConcerns.Logging.log4net.Loggers;
using CooksProjectCore.DAL.Asbtract;
using CooksProjectCore.Entities.Concrete;
using CooksProjectCore.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace CooksProjectCore.BLL.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDAL _userDAL;
        private readonly IMapper _mapper;
        public UserManager(IUserDAL userDAL,IMapper mapper)
        {
            _userDAL = userDAL;
            _mapper = mapper;
        }
        [RemoveCacheAspect(pattern:"IUserService.Get",Priority = 1)]
        [LogAspect(typeof(RequestsFileLogger),Priority = 2)]
        public void Add(User user)
        {
            _userDAL.Add(user);
        }
        [RemoveCacheAspect(pattern: "IUserService.Get", Priority = 1)]
        [LogAspect(typeof(RequestsFileLogger), Priority = 2)]
        public void Update(User user)
        {
            _userDAL.Update(user);
        }

        public void AddSocialMedia(SocialMedia socialMedia)
        {
            _userDAL.AddSocialMedia(socialMedia);
        }

        public void AssignRole(int userId)
        {
            _userDAL.AssignRole(userId);
        }

        public List<Role> GetRoles(User user)
        {
            return _userDAL.GetRoles(user);
        }

        public UserDTO_ForView GetUserByID(int userId)
        {
            var user = _userDAL.Get(x => x.ID == userId,new string[]{ "SocialMedia" });
            return _mapper.Map<UserDTO_ForView>(user);
        }

        public User GetUserByMail(string mail)
        {
            return _userDAL.Get(x => x.Email == mail);
        }
        [CacheAspect(duration:30,Priority = 1)]
        public List<UserDTO_ForEntities> GetUsers()
        {
            var users = _userDAL.GetList();
            return _mapper.Map<List<UserDTO_ForEntities>>(users);
        }

        public void UpdateSocialMedia(SocialMedia socialMedia)
        {
            _userDAL.UpdateSocialMedia(socialMedia);
        }
    }
}

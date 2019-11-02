using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CooksProjectCore.BLL.Abstract;
using CooksProjectCore.Core.Entities.Concrete;
using CooksProjectCore.Entities.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CooksProjectCore.WebAPI.Controllers
{
    [Route("api/")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        public UserController(IUserService _userService)
        {
            this._userService = _userService;
        }
        [HttpGet]
        [Route("users/{userId}")]
        [Authorize]
        public IActionResult GetUser(int userId)
        {
            var findUser = _userService.GetUserByID(userId);
            if (findUser == null)
                return NotFound();

            return Ok(new UserDTO
            {
                Name = findUser.Name,
                Surname = findUser.Surname,
                Email = findUser.Email,
                AddedDate = findUser.AddedDate,
                Job = findUser.Job
            });
        }
        [HttpGet]
        [Route("users/")]
        [Authorize(Roles = "Users.List")]
        public IActionResult GetUsers()
        {
            var userList = _userService.GetUsers();
            var users=new List<UserDTO>();
            foreach (var user in userList)
            {
                users.Add(new UserDTO
                {
                    Name = user.Name,
                    Surname = user.Surname,
                    Email = user.Email,
                    AddedDate = user.AddedDate,
                    Job = user.Job
                });
            }
            return Ok(users);
        }
        [HttpGet]
        [Route("users/{userId}/social-media")]
        [Authorize]
        public IActionResult GetSocialMedia(int userId)
        {
            var socialMedia = _userService.GetSocialMedia(userId);
            if (socialMedia == null)
                return NotFound();
            return Ok(socialMedia);
        }
        [HttpGet]
        [Route("users/{userId}/follows")]
        [Authorize]
        public IActionResult GetFollows(int userId)
        {
            var follows = _userService.Follows(userId);
            if (follows == null)
                return NotFound();
            return Ok(follows);
        }
        [HttpGet]
        [Route("users/{userId}/followers")]
        [Authorize]
        public IActionResult GetFollowers(int userId)
        {
            var followers = _userService.Followers(userId);
            if (followers == null)
                return NotFound();
            return Ok(followers);
        }

        [HttpPost]
        [Route("users/{userId}/social-media")]
        [Authorize]
        public IActionResult AddSocialMedia(int userId,SocialMedia socialMedia)
        {
            socialMedia.ID = Guid.NewGuid();
            socialMedia.UserID = userId;
            _userService.AddSocialMedia(socialMedia);
            return Ok();
        }
    }
}
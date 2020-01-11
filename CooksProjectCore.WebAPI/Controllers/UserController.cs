using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CooksProjectCore.BLL.Abstract;
using CooksProjectCore.Entities.Concrete;
using CooksProjectCore.Entities.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CooksProjectCore.WebAPI.Controllers
{
    [Route("api/")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IFollowService _followService;
        public UserController(IUserService userService,IFollowService followService)
        {
            _userService = userService;
            _followService = followService;
        }
        [HttpGet]
        [Route("users/{userId}")]
        public IActionResult GetUser(int userId)
        {
            var user = _userService.GetUserByID(userId);
            if (user == null) return NotFound();

            return Ok(user);
        }
        [HttpGet]
        [Route("users/")]
        public IActionResult GetUsers()
        {
            var userList = _userService.GetUsers();
            return Ok(userList);
        }
        [HttpPost]
        [HttpPut]
        [Route("users/")]
        public IActionResult Update(User user)
        {
            user.ModifiedDate = DateTime.Now;
            _userService.Update(user);
            return Ok();
        }
        [HttpPost]
        [Route("users/{userId}/follows")]
        public IActionResult AddFollow(FollowTable followTable)
        {
            _followService.AddFollow(followTable);
            return Ok();
        }
        [HttpDelete]
        [Route("users/{userId}/follows")]
        public IActionResult DeleteFollow(FollowTable followTable)
        {
            _followService.DeleteFollow(followTable);
            return Ok();
        }
        [HttpGet]
        [Route("users/{userId}/follows")]
        public IActionResult GetFollows(int userId)
        {
            var follows = _followService.Follows(userId);
            if (follows == null)
                return NotFound();
            return Ok(follows);
        }
        [HttpGet]
        [Route("users/{userId}/followers")]
        public IActionResult GetFollowers(int userId)
        {
            var followers = _followService.Followers(userId);
            if (followers == null)
                return NotFound();
            return Ok(followers);
        }
        [HttpPost]
        [Route("users/{userId}/social-media")]
        public IActionResult AddSocialMedia(int userId,SocialMedia socialMedia)
        {
            socialMedia.ID = Guid.NewGuid();
            socialMedia.UserID = userId;
            _userService.AddSocialMedia(socialMedia);
            return Ok();
        }
        [HttpPut]
        [Route("users/{userId}/social-media")]
        public IActionResult UpdateSocialMedia(SocialMedia socialMedia)
        {
            _userService.UpdateSocialMedia(socialMedia);
            return Ok();
        }
    }
}
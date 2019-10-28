using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CooksProjectCore.BLL.Abstract;
using CooksProjectCore.Entities.Concrete;
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
        [Route("users/")]
        public IActionResult GetUsers()
        {
            var result = _userService.GetUsers();
            if (result.Succes)
                return Ok(result.Data);
            return BadRequest(result.Message);
        }
        [HttpGet]
        [Route("users/member/{memberType}")]
        public IActionResult GetUsers(int memberType)
        {
            var result = _userService.GetUsers(memberType);
            if (result.Succes)
                return Ok(result.Data);
            return BadRequest(result.Message);
        }
        [HttpGet]
        [Route("users/{userId}")]
        public IActionResult GetUser(int userId)
        {
            var result = _userService.GetUser(userId);
            if (result.Succes)
                return Ok(result.Data);
            return BadRequest(result.Message);
        }
        [HttpPost]
        [Route("users/")]
        public IActionResult Add(User user)
        {
            var result = _userService.Add(user);
            if (result.Succes)
                return Ok(result.Message);
            return BadRequest(result.Message);
        }
        [HttpPut]
        [Route("users/")]
        public IActionResult Update(User user)
        {
            var result = _userService.Update(user);
            if (result.Succes)
                return Ok(result.Message);
            return BadRequest(result.Message);
        }
        [HttpDelete]
        [Route("users/")]
        public IActionResult Delete(User user)
        {
            var result = _userService.Delete(user);
            if (result.Succes)
                return Ok(result.Message);
            return BadRequest(result.Message);
        }
    }
}
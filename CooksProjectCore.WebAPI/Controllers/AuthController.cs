using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CooksProjectCore.BLL.Abstract;
using CooksProjectCore.Entities.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CooksProjectCore.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost]
        [Route("login")]
        public IActionResult Login(LoginDTO login)
        {
            var userToLogin = _authService.Login(login);
            if (!userToLogin.Succes)
                return BadRequest(userToLogin.Message);

            var result = _authService.CreateAccessToken(userToLogin.Data);
            if (!result.Succes)
                return BadRequest(result.Message);
            return Ok(result.Data);
        }
        [HttpPost]
        [Route("register")]
        public IActionResult Register(RegisterDTO register)
        {
            var userExist = _authService.UserExist(register.Email);
            if (!userExist.Succes)
                return BadRequest(userExist.Message);

            var registerResult = _authService.Register(register);
            var result = _authService.CreateAccessToken(registerResult.Data);

            if (!result.Succes)
                return BadRequest(result.Message);
            return Ok(result.Data);
        }
    }
}
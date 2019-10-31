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
        private IAuthService _authService;
        public AuthController(IAuthService _authService)
        {
            this._authService = _authService;
        }
        [Route("login")]
        [HttpPost]
        public ActionResult Login(LoginDTO loginDTO)
        {
            var userToLogin = _authService.Login(loginDTO);
            if (!userToLogin.Succes)
                return BadRequest(userToLogin.Message);

            var result = _authService.CreateAccessToken(userToLogin.Data);
            if (!result.Succes)
                return BadRequest(result.Message);

            return Ok(result.Data);
        }

        [Route("register")]
        [HttpPost]
        public ActionResult Register(RegisterDTO registerDTO)
        {
            var userExist = _authService.UserExist(registerDTO.Email);
            if (!userExist.Succes)
                return BadRequest(userExist.Message);

            var registerResult = _authService.Register(registerDTO);
            var result = _authService.CreateAccessToken(registerResult.Data);

            if (!result.Succes)
                return BadRequest(result.Message);

            return Ok(result.Data);
        }
    }
}
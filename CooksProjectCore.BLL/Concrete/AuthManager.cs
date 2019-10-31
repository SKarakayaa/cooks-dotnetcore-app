using CooksProjectCore.BLL.Abstract;
using CooksProjectCore.BLL.Constants;
using CooksProjectCore.Core.Entities.Concrete;
using CooksProjectCore.Core.Security;
using CooksProjectCore.Core.Security.Hashing;
using CooksProjectCore.Core.Utilities.Results;
using CooksProjectCore.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace CooksProjectCore.BLL.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;
        public AuthManager(IUserService _userService,ITokenHelper _tokenHelper)
        {
            this._tokenHelper = _tokenHelper;
            this._userService = _userService;
        }
        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var roles = _userService.GetRoles(user);
            var accessToken = _tokenHelper.CreateToken(user, roles);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
        }

        public IDataResult<User> Login(LoginDTO loginDTO)
        {
            var user = _userService.GetUserByMail(loginDTO.Email);
            if (user == null)
                return new ErrorDataResult<User>(Messages.UserNotFound);
            if (!HashingHelper.VerifyPasswordHash(loginDTO.Password, user.PasswordHash, user.PasswordSalt))
                return new ErrorDataResult<User>(Messages.PasswordVerifyError);

            return new SuccessDataResult<User>(user,Messages.SuccessLogin);
        }

        public IDataResult<User> Register(RegisterDTO registerDTO)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(registerDTO.Password,out passwordHash,out passwordSalt);
            var user = new User
            {
                Email = registerDTO.Email,
                Name = registerDTO.Name,
                Surname = registerDTO.Surname,
                AddedDate = DateTime.Now,
                Job = registerDTO.Job,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };
            _userService.Add(user);
            return new SuccessDataResult<User>(user, Messages.UserCreated);
        }

        public IResult UserExist(string mail)
        {
            if (_userService.GetUserByMail(mail) != null)
                return new ErrorResult(Messages.UserAlreadyExist);
            return new SuccessResult();
        }
    }
}

using AutoMapper;
using CooksProjectCore.BLL.Abstract;
using CooksProjectCore.BLL.Constants;
using CooksProjectCore.Core.Security;
using CooksProjectCore.Core.Security.Hashing;
using CooksProjectCore.Core.Utilities.Results;
using CooksProjectCore.Entities.Concrete;
using CooksProjectCore.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace CooksProjectCore.BLL.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly ITokenHelper _tokenHelper;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public AuthManager(ITokenHelper tokenHelper,IUserService userService,IMapper mapper)
        {
            _tokenHelper = tokenHelper;
            _userService = userService;
            _mapper = mapper;
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

            return new SuccessDataResult<User>(user);
        }

        public IDataResult<User> Register(RegisterDTO registerDTO)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(registerDTO.Password, out passwordHash, out passwordSalt);

            var user = new User
            {
                AddedDate = DateTime.Now,
                Email = registerDTO.Email,
                Job = registerDTO.Job,
                Name = registerDTO.Name,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Surname = registerDTO.Surname
            };
            _userService.Add(user);
            _userService.AssignRole(user.ID);
            return new SuccessDataResult<User>(user,Messages.UserCreated);
        }

        public IResult UserExist(string mail)
        {
            if (_userService.GetUserByMail(mail) != null)
                return new ErrorResult(Messages.UserAlreadyExist);
            return new SuccessResult();
        }
    }
}

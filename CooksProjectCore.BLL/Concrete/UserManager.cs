using CooksProjectCore.BLL.Abstract;
using CooksProjectCore.Core.Utilities.Results;
using CooksProjectCore.DAL.Asbtract;
using CooksProjectCore.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooksProjectCore.BLL.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDAL _userDAL;
        public UserManager(IUserDAL _userDAL)
        {
            this._userDAL = _userDAL;
        }
        public IResult Add(User user)
        {
            _userDAL.Add(user);
            return new SuccessResult("Hesap Başarıyla Oluşturuldu !...");
        }

        public IResult Delete(User user)
        {
            _userDAL.Remove(user);
            return new SuccessResult("Hesap Başarıyla Silindi !...");
        }

        public IDataResult<User> GetUser(int userId)
        {
            return new SuccessDataResult<User>(_userDAL.Get(f => f.ID == userId));
        }

        public IDataResult<List<User>> GetUsers()
        {
            return new SuccessDataResult<List<User>>(_userDAL.GetList().ToList());
        }

        public IDataResult<List<User>> GetUsers(int memberType)
        {
            return new SuccessDataResult<List<User>>(_userDAL.GetList(w => w.MemberType == memberType).ToList());
        }

        public IResult Update(User user)
        {
            _userDAL.Update(user);
            return new SuccessResult("Kullanıcı Bilgileri Başarıyla Güncellendi !...");
        }
    }
}

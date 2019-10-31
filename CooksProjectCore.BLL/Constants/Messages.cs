using System;
using System.Collections.Generic;
using System.Text;
using CooksProjectCore.Core.Entities.Concrete;

namespace CooksProjectCore.BLL.Constants
{
    public class Messages
    {
        public static string UserCreated = "Hesap Başarıyla Oluşturuldu !...";
        public static string UserAlreadyExist = "Bu Mail ile Kullanıcı Zaten Mevcut !..";
        public static string UserNotFound = "Böyle Bir Kullanıcı Bulunamadı !...";
        public static string SuccessLogin = "Başarıyla Giriş Yaptınız !...";
        public static string PasswordVerifyError = "Hatalı Şifre Girdiniz !...";
        public static string AccessTokenCreated = "Token Başarıyla Oluşturuldu !...";
    }
}

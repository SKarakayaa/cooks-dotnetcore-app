using System;
using System.Collections.Generic;
using System.Text;

namespace CooksProjectCore.BLL.Validation.FluentValidation
{
    public static class ErrorMessages
    {
        public static string NameContainsDigit = "Adınız Bir Harf İçeremez";
        public static string EmptyName = "Adınız Boş Geçilemez";

        public static string PasswordNull = "Şifre Boş Bırakılamaz";
        public static string PasswordLength = "Şifreniz 6-20 Aralığında Olmak Zorundadır";
        public static string PasswordUpper = "Şifrenizde En Az 1 Büyük Karakter Olmak Zorunda";
        public static string PasswordLower = "Şifrenizde En Az 1 Küçük Karakter Olmak Zorunda";
        public static string PasswordSpecialCharacter = "Şifreniz Özel Bir Karakter İçermek Zorunda";
        public static string PasswordDigit= "Şifreniz Sayısal Bir İfade İçermek Zorunda";

        public static string EmailEmpty= "Email Adresi Boş Geçilemez";
        public static string ValidateEmail = "Girdiğiniz Mail Adresi Uygun Bir Adres Değildir";

        public static string CommentNull = "Lütfen Bir Yorum Giriniz !";
        public static string CommentMaxLength = "Çok Fazla Karakter Girişi Yaptınız !";
    }
}

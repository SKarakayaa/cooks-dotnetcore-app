using CooksProjectCore.Entities.Dto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CooksProjectCore.BLL.Validation.FluentValidation
{
    public class LoginValidation:AbstractValidator<LoginDTO>
    {
        public LoginValidation()
        {
            RuleFor(r => r.Password).NotEmpty().NotNull().WithMessage(ErrorMessages.PasswordNull);
            RuleFor(r => r.Password).MinimumLength(6).MaximumLength(20).WithMessage(ErrorMessages.PasswordLength);
            RuleFor(r => r.Password).Matches("[A-Z]").WithMessage(ErrorMessages.PasswordUpper);
            RuleFor(r => r.Password).Matches("[a-z]").WithMessage(ErrorMessages.PasswordLower);
            RuleFor(r => r.Password).Matches("[^a-zA-Z0-9]").WithMessage(ErrorMessages.PasswordSpecialCharacter);
            RuleFor(r => r.Password).Matches("[0-9]").WithMessage(ErrorMessages.PasswordDigit);

            RuleFor(r => r.Email).NotNull().NotEmpty().WithMessage(ErrorMessages.EmailEmpty);
            RuleFor(r => r.Email).EmailAddress().WithMessage(ErrorMessages.ValidateEmail);
        }
    }
}

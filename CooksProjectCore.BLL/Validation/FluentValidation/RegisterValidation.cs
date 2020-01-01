using CooksProjectCore.Entities.Dto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooksProjectCore.BLL.Validation.FluentValidation
{
    public class RegisterValidation:AbstractValidator<RegisterDTO>
    {
        public RegisterValidation()
        {
            RuleFor(r => r.Name).NotEmpty().NotNull().WithMessage(ErrorMessages.EmptyName);
            RuleFor(r => r.Name).Must(CheckContainsNumber).WithMessage(ErrorMessages.NameContainsDigit);

            RuleFor(r => r.Surname).NotEmpty().NotNull().WithMessage(ErrorMessages.EmptyName);
            RuleFor(r => r.Surname).Must(CheckContainsNumber).WithMessage(ErrorMessages.NameContainsDigit);

            RuleFor(r => r.Password).NotEmpty().NotNull().WithMessage(ErrorMessages.PasswordNull);
            RuleFor(r => r.Password).MinimumLength(6).MaximumLength(20).WithMessage(ErrorMessages.PasswordLength);
            RuleFor(r => r.Password).Matches("[A-Z]").WithMessage(ErrorMessages.PasswordUpper);
            RuleFor(r => r.Password).Matches("[a-z]").WithMessage(ErrorMessages.PasswordLower);
            RuleFor(r => r.Password).Matches("[^a-zA-Z0-9]").WithMessage(ErrorMessages.PasswordSpecialCharacter);
            RuleFor(r => r.Password).Matches("[0-9]").WithMessage(ErrorMessages.PasswordDigit);

            RuleFor(r => r.Email).NotNull().NotEmpty().WithMessage(ErrorMessages.EmailEmpty);
            RuleFor(r => r.Email).EmailAddress().WithMessage(ErrorMessages.ValidateEmail);
        }

        private bool CheckContainsNumber(string arg)
        {
            if (arg.Any(char.IsDigit))
                return false;
            return true;
        }
    }
}

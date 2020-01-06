using CooksProjectCore.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CooksProjectCore.BLL.Validation.FluentValidation
{
    public class CommentValidation:AbstractValidator<Comment>
    {
        public CommentValidation()
        {
            RuleFor(c => c.Text).NotEmpty().NotNull().WithMessage(ErrorMessages.CommentNull);
            RuleFor(c => c.Text).MaximumLength(3999).WithMessage(ErrorMessages.CommentMaxLength);
        }
    }
}

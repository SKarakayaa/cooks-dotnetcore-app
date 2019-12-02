using CooksProjectCore.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CooksProjectCore.BLL.Validation.FluentValidation
{
    public class FoodValidation:AbstractValidator<Food>
    {
        public FoodValidation()
        {
            RuleFor(f => f.Name).NotEmpty();
            RuleFor(f => f.UserID).NotEmpty();
            RuleFor(f => f.Recipe).NotEmpty();
            RuleFor(f => f.Recipe).MaximumLength(8000);
            RuleFor(f => f.ImageUrl).NotEmpty();
        }
    }
}

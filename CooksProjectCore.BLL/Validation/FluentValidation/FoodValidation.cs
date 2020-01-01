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
            RuleFor(f => f.Name).NotNull().NotEmpty();
            RuleFor(f => f.Recipe).NotNull().NotEmpty();
            RuleFor(f => f.ImageUrl).NotNull().NotEmpty();
        }
    }
}

using Castle.DynamicProxy;
using CooksProjectCore.Core.CrossCuttingConcerns.Validation.FluentValidation;
using CooksProjectCore.Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooksProjectCore.Core.Aspects.Validation
{
    public class ValidationAspect:MethodInterception
    {
        Type _validator;
        public ValidationAspect(Type _validator)
        {
            if (!typeof(IValidator).IsAssignableFrom(_validator))
                throw new Exception();
            this._validator = _validator;
        }

        public override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validator);
            var entityType = _validator.BaseType.GetGenericArguments()[0];
            var entities = invocation.Arguments.Where(w => w.GetType() == entityType);

            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}

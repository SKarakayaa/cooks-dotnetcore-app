using Castle.DynamicProxy;
using CooksProjectCore.Core.Utilities.Interceptor;
using CooksProjectCore.Core.Utilities.Messages;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using CooksProjectCore.Core.CrossCuttingConcerns.Validation;

namespace CooksProjectCore.Core.Aspects.Validation
{
    public class AspectValidation:MethodInterception
    {
        private Type _validatorType;
        public AspectValidation(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
                throw new System.Exception(AspectMessages.WrongValidationType);
            _validatorType = validatorType;
        }
        public override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            var entities = invocation.Arguments.Where(W => W.GetType() == entityType);
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}

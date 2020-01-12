using Castle.DynamicProxy;
using CooksProjectCore.Core.Aspects.Exception;
using CooksProjectCore.Core.CrossCuttingConcerns.Logging.log4net.Loggers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CooksProjectCore.Core.Utilities.Interceptor
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttribues = type.GetCustomAttributes<MethodInterceptorBaseAttribute>(true).ToList();
            var methodAttributes = type.GetMethod(method.Name).GetCustomAttributes<MethodInterceptorBaseAttribute>(true);
            classAttribues.AddRange(methodAttributes);
            classAttribues.Add(new ExceptionAspect(typeof(ExceptionFileLogger)));
            return classAttribues.OrderBy(o => o.Priority).ToArray();
        }
    }
}

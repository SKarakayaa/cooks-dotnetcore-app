using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Text;

namespace CooksProjectCore.Core.Utilities.Interceptor
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class,AllowMultiple =true,Inherited =true)]
    public abstract class MethodInterceptorBaseAttribute : Attribute, IInterceptor
    {
        public int Priority{ get; set; }
        public virtual void Intercept(IInvocation invocation)
        {
        }
    }
}

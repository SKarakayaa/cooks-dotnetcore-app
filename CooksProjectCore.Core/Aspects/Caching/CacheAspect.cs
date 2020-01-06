using CooksProjectCore.Core.CrossCuttingConcerns.Caching;
using CooksProjectCore.Core.Utilities.Interceptor;
using CooksProjectCore.Core.Utilities.IoC;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Castle.DynamicProxy;
using System.Linq;

namespace CooksProjectCore.Core.Aspects.Caching
{
    public class CacheAspect:MethodInterception
    {
        private int _duration;
        private ICacheManager _cache;
        public CacheAspect(int duration)
        {
            _duration = duration;
            _cache = ServiceTools.ServiceProvider.GetService<ICacheManager>();
        }
        public override void Intercept(IInvocation invocation)
        {
            var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}");
            var arguments = invocation.Arguments.ToList();
            var key = $"{methodName}({string.Join(",", arguments.Select(x => x?.ToString() ?? "<Null>"))})";
            
            if(_cache.IsAdd(key))
            {
                invocation.ReturnValue = _cache.Get(key);
                return;
            }
            invocation.Proceed();
            _cache.Add(key, invocation.ReturnValue, _duration);
        }
    }
}

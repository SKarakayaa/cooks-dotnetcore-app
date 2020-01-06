using CooksProjectCore.Core.CrossCuttingConcerns.Caching;
using CooksProjectCore.Core.Utilities.Interceptor;
using CooksProjectCore.Core.Utilities.IoC;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Castle.DynamicProxy;

namespace CooksProjectCore.Core.Aspects.Caching
{
    public class RemoveCacheAspect:MethodInterception
    {
        private string _pattern;
        private ICacheManager _cache;
        public RemoveCacheAspect(string pattern)
        {
            _pattern = pattern;
            _cache = ServiceTools.ServiceProvider.GetService<ICacheManager>();
        }
        public override void OnSuccess(IInvocation invocation)
        {
            _cache.RemoveByPattern(_pattern);
        }
    }
}

using CooksProjectCore.Core.CrossCuttingConcerns.Caching;
using CooksProjectCore.Core.Utilities.Interceptors;
using CooksProjectCore.Core.Utilities.IoC;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Castle.DynamicProxy;

namespace CooksProjectCore.Core.Aspects.Caching
{
    public class CacheRemoveAspect:MethodInterception
    {
        private string _pattern;
        private ICacheManager _cacheManager;
        public CacheRemoveAspect(string _pattern)
        {
            this._pattern = _pattern;
            _cacheManager = ServiceTools.ServiceProvider.GetService<ICacheManager>();
        }
        public override void OnSuccess(IInvocation invocation)
        {
            _cacheManager.RemoveByPattern(_pattern);
        }
    }
}

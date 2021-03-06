﻿using CooksProjectCore.Core.CrossCuttingConcerns.Caching;
using CooksProjectCore.Core.CrossCuttingConcerns.Caching.Microsoft;
using CooksProjectCore.Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CooksProjectCore.Core.DependencyResolver
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddSingleton<ICacheManager, MemoryCacheManager>();
        }
    }
}

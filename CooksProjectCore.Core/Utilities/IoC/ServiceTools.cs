﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CooksProjectCore.Core.Utilities.IoC
{
    public class ServiceTools
    {
        public static IServiceProvider ServiceProvider{ get; set; }
        
        public static IServiceCollection Create(IServiceCollection services)
        {
            ServiceProvider = services.BuildServiceProvider();
            return services;
        }
    }
}

using CooksProjectCore.Core.Utilities.Interceptor;
using CooksProjectCore.Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Castle.DynamicProxy;
using CooksProjectCore.Core.Extensions;
using CooksProjectCore.Core.Utilities.Messages;

namespace CooksProjectCore.Core.Aspects.Auth
{
    public class AuthAspect:MethodInterception
    {
        private string[] _roles;
        private IHttpContextAccessor _httpContextAccessor;
        public AuthAspect(string roles)
        {
            _roles = roles.Split(',');
            _httpContextAccessor = ServiceTools.ServiceProvider.GetService<IHttpContextAccessor>();
        }
        public override void OnBefore(IInvocation invocation)
        {
            var userRoles = _httpContextAccessor.HttpContext.User.ClaimRoles();
            foreach (var role in _roles )
            {
                if (userRoles.Contains(role))
                    return;
            }
            throw new Exception(AspectMessages.AuthorizedDenied);
        }
    }
}

using Autofac;
using Autofac.Extras.DynamicProxy;
using AutoMapper;
using CooksProjectCore.BLL.Abstract;
using CooksProjectCore.BLL.Concrete;
using CooksProjectCore.BLL.Mapping;
using CooksProjectCore.Core.Security;
using CooksProjectCore.Core.Security.Jwt;
using CooksProjectCore.Core.Utilities.Interceptor;
using CooksProjectCore.DAL.Asbtract;
using CooksProjectCore.DAL.Concrete;
using CooksProjectCore.DAL.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CooksProjectCore.BLL.DependencyResolvers.Autofac
{
    public class AutofacBussinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<FoodManager>().As<IFoodService>();
            builder.RegisterType<EFFoodDAL>().As<IFoodDAL>();

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EFUserDAL>().As<IUserDAL>();

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            builder.RegisterType<CommentManager>().As<ICommentService>();
            builder.RegisterType<EFCommentDAL>().As<ICommentDAL>();

            builder.RegisterType<EFFollowDAL>().As<IFollowDAL>();
            builder.RegisterType<FollowManager>().As<IFollowService>();

            builder.RegisterType<EFLikeDAL>().As<ILikeDAL>();
            builder.RegisterType<LikeManager>().As<ILikeService>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces().EnableInterfaceInterceptors(new Castle.DynamicProxy.ProxyGenerationOptions()
            {
                Selector = new AspectInterceptorSelector()
            }).SingleInstance();
        }
    }
}

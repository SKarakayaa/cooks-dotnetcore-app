using Castle.DynamicProxy;
using CooksProjectCore.Core.CrossCuttingConcerns.Logging;
using CooksProjectCore.Core.CrossCuttingConcerns.Logging.log4net;
using CooksProjectCore.Core.Utilities.Interceptor;
using CooksProjectCore.Core.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace CooksProjectCore.Core.Aspects.Logging
{
    public class LogAspect:MethodInterception
    {
        private LoggerServiceBase _loggerServiceBase;
        public LogAspect(Type loggerService)
        {
            if (loggerService.BaseType != typeof(LoggerServiceBase))
                throw new System.Exception(AspectMessages.WrongValidationType);
            _loggerServiceBase = (LoggerServiceBase)Activator.CreateInstance(loggerService);
        }
        public override void OnBefore(IInvocation invocation)
        {
            _loggerServiceBase.Info(GetLogDetails(invocation));
        }

        private LogDetail GetLogDetails(IInvocation invocation)
        {
            var logParamaters = new List<LogParamater>();
            for (int i = 0; i < invocation.Arguments.Length; i++)
            {
                logParamaters.Add(new LogParamater
                {
                    Name = invocation.GetConcreteMethod().GetParameters()[i].Name,
                    Value = invocation.Arguments[i],
                    Type = invocation.Arguments[i].GetType().Name
                });
            }

            var logDetail = new LogDetail
            {
                MethodName = invocation.Method.Name,
                ServiceName = invocation.Method.ReflectedType.Name,
                RequestDate=DateTime.Now.ToString("dd MMMM yyyy - dddd, HH:mm:ss"),
                LogParamaters = logParamaters
            };
            return logDetail;
        }

    }
}

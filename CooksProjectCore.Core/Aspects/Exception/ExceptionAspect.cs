using Castle.DynamicProxy;
using CooksProjectCore.Core.CrossCuttingConcerns.Logging;
using CooksProjectCore.Core.CrossCuttingConcerns.Logging.log4net;
using CooksProjectCore.Core.Utilities.Interceptor;
using CooksProjectCore.Core.Utilities.Messages;
using CooksProjectCore.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace CooksProjectCore.Core.Aspects.Exception
{
    public class ExceptionAspect : MethodInterception
    {
        private LoggerServiceBase _loggerServiceBase;
        public ExceptionAspect(Type loggerService)
        {
            if (loggerService.BaseType != typeof(LoggerServiceBase))
                throw new System.Exception(AspectMessages.WrongLoggerType);
            _loggerServiceBase = (LoggerServiceBase)Activator.CreateInstance(loggerService);
        }
        public override void OnException(IInvocation invocation, System.Exception e)
        {
            _loggerServiceBase.Error(GetLogDetail(invocation, e));
        }
        private ExceptionLogDetail GetLogDetail(IInvocation invocation, System.Exception e)
        {
            var logParamaters = new List<LogParamater>();
            for (int i = 0; i < invocation.Arguments.Length; i++)
            {
                LogParamater logParamater = new LogParamater();
                logParamater.Name = invocation.GetConcreteMethod().GetParameters()[i].Name;
                logParamater.Type = invocation.Arguments[i].GetType().Name;
                logParamater.Value = invocation.Arguments[i];

                if (logParamater.Value.GetType() == typeof(LoginDTO))
                {
                    ((LoginDTO)logParamater.Value).Email = "xxxxxxxxxxx@xxxx.com";
                    ((LoginDTO)logParamater.Value).Password = "***************";
                }
                if (logParamater.Value.GetType() == typeof(RegisterDTO))
                {
                    ((RegisterDTO)logParamater.Value).Email = "xxxxxxxxxxx@xxxx.com";
                    ((RegisterDTO)logParamater.Value).Password = "***************";
                }

                logParamaters.Add(logParamater);
            }
            var logDetail = new ExceptionLogDetail
            {
                ExceptionMessage = e.Message,
                LogParamaters = logParamaters,
                MethodName = invocation.Method.Name,
                RequestDate = DateTime.Now.ToString("dd MM yyyy - dddd, HH:mm:ss"),
                ServiceName = invocation.Method.ReflectedType.Name
            };
            return logDetail;
        }
    }
}

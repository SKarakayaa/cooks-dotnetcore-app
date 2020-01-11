using CooksProjectCore.Core.CrossCuttingConcerns.Logging.log4net;
using CooksProjectCore.Core.Utilities.IoC;
using CooksProjectCore.Core.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using CooksProjectCore.Core.Utilities.Interceptor;
using Castle.DynamicProxy;
using CooksProjectCore.Core.CrossCuttingConcerns.Logging;

namespace CooksProjectCore.Core.Aspects.Performance
{
    public class PerformanceAspect:MethodInterception
    {
        private LoggerServiceBase _loggerServiceBase;
        private Stopwatch _stopwatch;
        private int _interval;
        public PerformanceAspect(Type loggerService,int interval)
        {
            if (loggerService.BaseType != typeof(LoggerServiceBase))
                throw new System.Exception(AspectMessages.WrongLoggerType);
            _loggerServiceBase = (LoggerServiceBase)Activator.CreateInstance(loggerService);
            _interval = interval;
            _stopwatch = ServiceTools.ServiceProvider.GetService<Stopwatch>();
        }
        public override void OnBefore(IInvocation invocation)
        {
            _stopwatch.Start();
        }
        public override void OnAfter(IInvocation invocation)
        {
            if(_stopwatch.Elapsed.TotalSeconds > _interval)
            {
                _loggerServiceBase.Warn(GetLogDetail(invocation));
            }
            _stopwatch.Reset();
        }
        public PerformanceLogDetail GetLogDetail(IInvocation invocation)
        {
            var logParamaters = new List<LogParamater>();
            for (int i = 0; i < invocation.Arguments.Length; i++)
            {
                logParamaters.Add(new LogParamater
                {
                    Name = invocation.GetConcreteMethod().GetParameters()[i].Name,
                    Type = invocation.Arguments[i].GetType().Name,
                    Value = invocation.Arguments[i]
                });
            }
            var performanceLogDetail = new PerformanceLogDetail
            {
                Interval = _stopwatch.Elapsed.TotalSeconds,
                LogParamaters = logParamaters,
                MethodName = invocation.Method.Name,
                ServiceName = invocation.Method.ReflectedType.Name,
                RequestDate = DateTime.Now.ToString("dd MM yyyy - dddd, HH:mm:ss")
            };
            return performanceLogDetail;
        }
    }
}

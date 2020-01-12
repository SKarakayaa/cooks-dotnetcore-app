using System;
using System.Collections.Generic;
using System.Text;

namespace CooksProjectCore.Core.CrossCuttingConcerns.Logging.log4net.Loggers
{
    public class ExceptionFileLogger : LoggerServiceBase
    {
        public ExceptionFileLogger() : base("exceptionLogger")
        {
        }
    }
}

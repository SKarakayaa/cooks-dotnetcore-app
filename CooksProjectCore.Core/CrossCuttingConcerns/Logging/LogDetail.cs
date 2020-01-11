using System;
using System.Collections.Generic;
using System.Text;

namespace CooksProjectCore.Core.CrossCuttingConcerns.Logging
{
    public class LogDetail
    {
        public string MethodName{ get; set; }
        public string ServiceName{ get; set; }
        public string RequestDate{ get; set; }
        public List<LogParamater> LogParamaters{ get; set; }
    }
}

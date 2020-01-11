using System;
using System.Collections.Generic;
using System.Text;

namespace CooksProjectCore.Core.CrossCuttingConcerns.Logging
{
    public class PerformanceLogDetail:LogDetail
    {
        public double Interval{ get; set; }
    }
}

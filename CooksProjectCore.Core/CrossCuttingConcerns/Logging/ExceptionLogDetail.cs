using System;
using System.Collections.Generic;
using System.Text;

namespace CooksProjectCore.Core.CrossCuttingConcerns.Logging
{
    public class ExceptionLogDetail:LogDetail
    {
        public string ExceptionMessage{ get; set; }
    }
}

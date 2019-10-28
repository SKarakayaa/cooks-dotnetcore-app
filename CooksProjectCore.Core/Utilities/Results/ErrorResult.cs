using System;
using System.Collections.Generic;
using System.Text;

namespace CooksProjectCore.Core.Utilities.Results
{
    class ErrorResult : Result
    {
        public ErrorResult() : base(false)
        {
        }

        public ErrorResult(string message) : base(false, message)
        {
        }
    }
}

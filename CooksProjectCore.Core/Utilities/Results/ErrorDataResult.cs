﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CooksProjectCore.Core.Utilities.Results
{
    class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult(T data) : base(data, false)
        {
        }

        public ErrorDataResult(T data,string message) : base(data, false, message)
        {
        }
    }
}

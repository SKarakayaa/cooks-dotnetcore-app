using System;
using System.Collections.Generic;
using System.Text;

namespace CooksProjectCore.Core.Utilities.Results
{
    public class Result : IResult
    {
        public bool Succes { get; }

        public string Message { get; }

        public Result(bool success,string message):this(success)
        {
            Message = message;
        }
        public Result(bool success)
        {
            Succes = success;
        }
    }
}

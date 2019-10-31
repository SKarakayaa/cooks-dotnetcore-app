using System;
using System.Collections.Generic;
using System.Text;

namespace CooksProjectCore.Core.Security
{
    public class AccessToken
    {
        public string Token{ get; set; }
        public DateTime Expiration{ get; set; }
    }
}

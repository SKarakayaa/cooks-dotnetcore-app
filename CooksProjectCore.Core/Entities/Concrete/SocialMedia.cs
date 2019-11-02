using System;
using System.Collections.Generic;
using System.Text;

namespace CooksProjectCore.Core.Entities.Concrete
{
    public class SocialMedia:IEntity
    {
        public Guid ID{ get; set; }
        public int UserID{ get; set; }
        public string Facebook{ get; set; }
        public string Instagram{ get; set; }
        public string Linkedln{ get; set; }
        public string Twitter{ get; set; }
    }
}

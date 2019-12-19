using CooksProjectCore.Core.DAL.EntityFramework;
using CooksProjectCore.DAL.Asbtract;
using CooksProjectCore.DAL.Concrete.EntityFramework.Context;
using CooksProjectCore.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooksProjectCore.DAL.Concrete.EntityFramework
{
    public class EFCommentDAL : EFEntityRepositoryBase<Comment, CooksContext>, ICommentDAL
    {
    }
}

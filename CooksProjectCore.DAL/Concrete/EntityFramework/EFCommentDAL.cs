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
        public void AddCommentReply(CommentReply commentReply)
        {
            using (var db = new CooksContext())
            {
                db.Entry(commentReply).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                db.SaveChanges();
            }
        }

        public void DeleteCommentReply(Guid replyId)
        {
            using (var db = new CooksContext())
            {
                var commentReply = db.CommentReplies.FirstOrDefault(f => f.ID == replyId);
                if(commentReply!=null)
                {
                    db.Entry(commentReply).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                    db.SaveChanges();
                }
            }
        }

        public List<CommentReply> GetCommentReplies(Guid commentId)
        {
            using (var db = new CooksContext())
            {
                return db.CommentReplies.Where(w => w.CommentID == commentId).ToList();
            }
        }
    }
}

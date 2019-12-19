using CooksProjectCore.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace CooksProjectCore.Core.DAL.EntityFramework
{
    public class EFEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            using (var db =new TContext())
            {
                db.Entry(entity).State = EntityState.Added;
                db.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter,string[] children = null)
        {
            using (var db = new TContext())
            {
                IQueryable<TEntity> query = db.Set<TEntity>();
                if (children != null)
                {
                    foreach (var entity in children)
                    {
                        query = query.Include(entity);
                    }
                }
                return query.SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null, string[] children = null)
        {
            using (var db = new TContext())
            {
                IQueryable<TEntity> query = db.Set<TEntity>();
                if(children!=null)
                {
                    foreach (string entity in children)
                    {
                        query = query.Include(entity);
                    }
                }
                return filter == null
                    ? query.ToList()
                    : query.Where(filter).ToList();
            }
        }

        public void Remove(TEntity entity)
        {
            using (var db = new TContext())
            {
                db.Entry(entity).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public void Update(TEntity entity)
        {
            using (var db = new TContext())
            {
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}

using CooksProjectCore.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace CooksProjectCore.Core.DAL
{
    public interface IEntityRepository<T> where T:class,IEntity,new()
    {
        List<T> GetList(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Remove(T entity);
        void Update(T entity);
    }
}

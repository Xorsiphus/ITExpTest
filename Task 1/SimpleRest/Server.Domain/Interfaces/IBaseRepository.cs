using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Server.Domain.Entities;

namespace Server.Domain.Interfaces
{
    public interface IBaseRepository<T> where T : class, IEntity
    {
        Task Save(T entity);
        Task SaveAll(IEnumerable<T> entities);
        Task<IEnumerable<T>> Query(int take, int offset);
        Task<int> GetCount(Expression<Func<T, bool>> condition);
    }
}
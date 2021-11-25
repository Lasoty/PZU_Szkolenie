using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DeskBooking.Domain.Repositories
{
    public interface IRepository<T>
    {
        IQueryable<T> Find(Expression<Func<T, bool>> predicate);

        IQueryable<T> GetAll();

        void Add(T entity);

        Task AddAsync(T entity);

        void AddRange(IEnumerable<T> entities);

        Task AddRangeAsync(IEnumerable<T> entities);

        void Update(T entity);

        Task UpdateAsync(T entity);

        void Delete(T entity);

        void RemoveRange(IEnumerable<T> entities);

        Task RemoveRangeAsync(IEnumerable<T> entities);
    }
}

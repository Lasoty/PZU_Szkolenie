using DeskBooking.Domain.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DeskBooking.Domain.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext dbContext;

        public BaseRepository(
            ApplicationDbContext dbContext
            )
        {
            this.dbContext = dbContext;
            DbSet = dbContext.Set<T>();
        }

        protected DbSet<T> DbSet { get; set; }

        public virtual void Add(T entity)
        {
            DbSet.Add(entity);
            dbContext.SaveChanges();
        }

        public virtual async Task AddAsync(T entity)
        {
            EntityEntry dbEntityEntry = dbContext.Entry(entity);

            if (dbEntityEntry.State != EntityState.Detached)
                dbEntityEntry.State = EntityState.Added;
            else
                await DbSet.AddAsync(entity);

            await dbContext.SaveChangesAsync();
        }

        public virtual void AddRange(IEnumerable<T> entities)
        {
            dbContext.Set<T>().AddRange(entities);
            dbContext.SaveChanges();
        }

        public virtual async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await dbContext.Set<T>().AddRangeAsync(entities);
            await dbContext.SaveChangesAsync();
        }

        public virtual void Delete(T entity)
        {
            EntityEntry dbEntityEntry = dbContext.Entry(entity);
            if (dbEntityEntry.State != EntityState.Deleted)
            {
                dbEntityEntry.State = EntityState.Deleted;
            }
            else
            {
                DbSet.Attach(entity);
                DbSet.Remove(entity);
            }

            dbContext.SaveChanges();
        }

        public virtual IQueryable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public virtual IQueryable<T> GetAll()
        {
            return DbSet;
        }

        public virtual void RemoveRange(IEnumerable<T> entities)
        {
            dbContext.Set<T>().RemoveRange(entities);
            dbContext.SaveChanges();
        }

        public virtual async Task RemoveRangeAsync(IEnumerable<T> entities)
        {
            dbContext.Set<T>().RemoveRange(entities);
            await dbContext.SaveChangesAsync();
        }

        public virtual void Update(T entity)
        {
            EntityEntry dbEntityEntry = dbContext.Entry(entity);
            if (dbEntityEntry.State == EntityState.Detached) DbSet.Attach(entity);
            dbEntityEntry.State = EntityState.Modified;
            dbContext.SaveChanges();
        }

        public virtual async Task UpdateAsync(T entity)
        {
            EntityEntry dbEntityEntry = dbContext.Entry(entity);
            if (dbEntityEntry.State == EntityState.Detached) DbSet.Attach(entity);
            dbEntityEntry.State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
        }
    }
}
